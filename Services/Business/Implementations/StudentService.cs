using System.Text.Json;
using AutoMapper;
using StageWise.Dtos.Student.Request;
using StageWise.Dtos.Student.Response;
using StageWise.Helpers;
using StageWise.Helpers.Exceptions;
using StageWise.Helpers.Interfaces;
using StageWise.Models;
using StageWise.Repositories.Interfaces;
using StageWise.Services.Business.Interfaces;
using StageWise.Services.Infrastructure.Interfaces;

namespace StageWise.Services.Business.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMessageQueue _messageQueue;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public StudentService(IStudentRepository studentRepository,IMapper mapper,IMessageQueue messageQueue,IPasswordHasher passwordHasher)
        {
            _studentRepository = studentRepository;
            _messageQueue = messageQueue;   
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }
        public async Task<CreateStudentResponse> CreateStudentAsync(CreateStudentRequest request)
        {
            var existingStudent=await _studentRepository.GetByEmailAsync(request.Email);
            if (existingStudent != null) throw new AppException("Student already exists", 409);
            var password = PasswordGenerator.GeneratePassword();
            var hashedPassword = _passwordHasher.HashPassword(password);
            var student = _mapper.Map<Student>(request);
            student.Password = hashedPassword;
            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveAsync();
            var emailMessage = new
            {
                To = request.Email,
                Subject = "Student Account Created",
                Body = $"Hello {request.Name}, your Student password is: {password}"
            };

            var message = JsonSerializer.Serialize(emailMessage);

            await _messageQueue.Publish("EmailQueue", message);

            return new CreateStudentResponse
            {
                Success = true,
                Message = "Student created successfully. Password sent to email."
            };
        }

        public async Task<DeleteStudentResponse> DeleteStudentAsync(int Id)
        {
            var student = await _studentRepository.GetByIdAsync(Id);
            if (student == null) throw new AppException("Student not found", 404);
            await _studentRepository.DeleteAsync(student);
            await _studentRepository.SaveAsync();
            return new DeleteStudentResponse
            {
                Success = true,
                Message = "Student deleted successfully"
            };
        }

        public async Task<GetStudentResponse> GetStudentAsync(int Id)
        {
            var student = await _studentRepository.GetByIdAsync(Id);
            if (student == null) throw new AppException("Student Not found", 404);
            return _mapper.Map<GetStudentResponse>(student);
        }

        public async Task<List<GetStudentResponse>> GetStudentsAsync()
        {
           var students=await _studentRepository.GetAllAsync();
            if (students.Count == 0) throw new AppException("No Students found", 404);
            return _mapper.Map<List<GetStudentResponse>>(students);
        }
    }
}