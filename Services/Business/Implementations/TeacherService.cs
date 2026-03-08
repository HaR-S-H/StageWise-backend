using System.Text.Json;
using AutoMapper;
using StageWise.Dtos.Teacher.Request;
using StageWise.Dtos.Teacher.Response;
using StageWise.Helpers;
using StageWise.Helpers.Exceptions;
using StageWise.Helpers.Interfaces;
using StageWise.Models;
using StageWise.Repositories.Interfaces;
using StageWise.Services.Business.Interfaces;
using StageWise.Services.Infrastructure.Interfaces;
using StageWise.Services.Infrastructure.Models;

namespace StageWise.Services.Business.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly ICurrentUserService _currentUser;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMessageQueue _messageQueue;
        private readonly IMapper _mapper;
        private readonly IS3Service _s3Service;
        public TeacherService(ICurrentUserService currentUserService, ITeacherRepository teacherRepository, IPasswordHasher passwordHasher, IMessageQueue messageQueue, IMapper mapper, IS3Service s3Service)
        {
            _currentUser = currentUserService;
            _teacherRepository = teacherRepository;
            _passwordHasher = passwordHasher;
            _messageQueue = messageQueue;
            _mapper = mapper;
            _s3Service = s3Service;
        }

        public async Task<CreateTeacherResponse> CreateTeacherAsync(CreateTeacherRequest request)
        {
            var existingTeacher = await _teacherRepository.GetByEmailAsync(request.Email);

            if (existingTeacher != null)
                throw new AppException("teacher already exists", 409);

            var password = PasswordGenerator.GeneratePassword();

            var hashedPassword = _passwordHasher.HashPassword(password);

            var teacher = _mapper.Map<Teacher>(request);
            teacher.Password = hashedPassword;
            await _teacherRepository.AddAsync(teacher);
            await _teacherRepository.SaveAsync();

            var emailMessage = new
            {
                To = request.Email,
                Subject = "Teacher Account Created",
                Body = $"Hello {request.Name}, your teacher password is: {password}"
            };

            var message = JsonSerializer.Serialize(emailMessage);

            await _messageQueue.Publish("EmailQueue", message);

            return new CreateTeacherResponse
            {
                Success = true,
                Message = "Teacher created successfully. Password sent to email."
            };
        }

        public async Task<DeleteTeacherResponse> DeleteTeacherAsync(DeleteTeacherRequest request)
        {
            var teacher = await _teacherRepository.GetByIdAsync(request.Id);
            if (teacher == null) throw new AppException("Teacher not found", 404);
            await _teacherRepository.DeleteAsync(teacher);
            await _teacherRepository.SaveAsync();
            return new DeleteTeacherResponse { Success = true, Message = "Teacher deleted successfully" };
        }

        public async Task<GetTeacherResponse> GetTeacherAsync()
        {
            var teacher = await _teacherRepository.GetByEmailAsync(_currentUser.Email);
            if (teacher == null) throw new AppException("Teacher not found", 404);
            return _mapper.Map<GetTeacherResponse>(teacher);
        }

        public async Task<List<GetTeacherResponse>> GetTeachersAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            if (teachers.Count == 0) throw new AppException("No teachers found", 404);
            return _mapper.Map<List<GetTeacherResponse>>(teachers);
        }

        public async Task<UpdateTeacherResponse> UpdateTeacherAsync(UpdateTeacherRequest request)
        {
            var teacher = await _teacherRepository.GetByIdAsync(request.Id);

            if (teacher == null) throw new AppException("Teacher not found", 404);

            if (request.Name != null)
                teacher.Name = request.Name;

            if (request.Avatar != null)
            {
                if (request.Avatar != null)
                {
                    var key = $"avatars/{Guid.NewGuid()}_{request.Avatar.FileName}";

                    teacher.Avatar = key;

                    using var memoryStream = new MemoryStream();
                    await request.Avatar.CopyToAsync(memoryStream);

                    var fileMessage = new S3UploadMessage
                    {
                        FileBytes = memoryStream.ToArray(),
                        FileName = request.Avatar.FileName,
                        ContentType = request.Avatar.ContentType,
                        Key = key
                    };

                    var message = JsonSerializer.Serialize(fileMessage);

                    await _messageQueue.Publish("S3UploadQueue", message);
                }
            }

            if (request.BlockNumber != null)
                teacher.BlockNumber = request.BlockNumber;

            if (request.CabinNumber != null)
                teacher.CabinNumber = request.CabinNumber;

            if (request.ContactNumber != null)
                teacher.ContactNumber = request.ContactNumber;

            await _teacherRepository.UpdateAsync(teacher);
            await _teacherRepository.SaveAsync();

            return new UpdateTeacherResponse
            {
                Success = true,
                Message = $"Update Teacher {request.Name} Successfully."
            };
        }
    }
}