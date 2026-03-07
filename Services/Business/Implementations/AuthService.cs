using StageWise.Dtos.Auth.Response;
using StageWise.Helpers.Enums;
using StageWise.Helpers.Interfaces;
using StageWise.Repositories.Interfaces;
using StageWise.Dtos.Auth.Request;
using AutoMapper;
using StageWise.Services.Business.Interfaces;
using StageWise.Helpers;
using System.Text.Json;
using StageWise.Services.Infrastructure.Interfaces;

namespace StageWise.Services.Business.Implementations
{
    public class AuthService:IAuthService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IHodRepository _hodRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;
        private readonly IMessageQueue _messageQueue;

        public AuthService(IPasswordHasher passwordHasher, IHodRepository hodRepository, IStudentRepository studentRepository, ITeacherRepository teacherRepository,IMapper mapper,IAdminRepository adminRepository,IMessageQueue messageQueue)
        {
            _passwordHasher = passwordHasher;
            _hodRepository = hodRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _adminRepository = adminRepository;
            _mapper = mapper;
            _messageQueue = messageQueue;

        }

        public async Task<ForgetPasswordResponse> ForgetPasswordAsync(ForgetPasswordRequest request)
        {
            var password = PasswordGenerator.GeneratePassword();
            var hashedPassword = _passwordHasher.HashPassword(password);
            var email = request.Email;
            // Check Admin
            var admin = await _adminRepository.GetByEmailAsync(email);
            if (admin != null)
            {
                admin.Password = hashedPassword;

                await _adminRepository.UpdateAsync(admin);
                await _adminRepository.SaveAsync();
                var emailMessage = new
                {
                    To = request.Email,
                    Subject = "New Password Created",
                    Body = $"Hello {admin.Name}, your admin password is: {password}"
                };

                var message = JsonSerializer.Serialize(emailMessage);

                // 6️⃣ Send message to RabbitMQ
                await _messageQueue.Publish("EmailQueue", message);
            }

            // Check HOD
            var hod = await _hodRepository.GetByEmailAsync(email);
            if (hod != null)
            {
                hod.Password = hashedPassword;

                await _hodRepository.UpdateAsync(hod);
                await _hodRepository.SaveAsync();

                var emailMessage = new
                {
                    To = request.Email,
                    Subject = "new Password Created",
                    Body = $"Hello {hod.Name}, your Hod password is: {password}"
                };

                var message = JsonSerializer.Serialize(emailMessage);

                // 6️⃣ Send message to RabbitMQ
                await _messageQueue.Publish("EmailQueue", message);
            }

            // Check Student
            // var student = await _studentRepository.GetByEmailAsync(email);
            // if (student != null)
            // {
            //     student.Password = hashedPassword;

            //     await _studentRepository.UpdateAsync(student);
            //     await _studentRepository.SaveAsync();

            //     await SendPasswordEmail(email, student.Name, password);
            //     return true;
            // }

            // // Check Teacher
            // var teacher = await _teacherRepository.GetByEmailAsync(email);
            // if (teacher != null)
            // {
            //     teacher.Password = hashedPassword;

            //     await _teacherRepository.UpdateAsync(teacher);
            //     await _teacherRepository.SaveAsync();

            //     await SendPasswordEmail(email, teacher.Name, password);
            //     return true;
            // }

            // return false;
            return new ForgetPasswordResponse { Success = true, Message = $"Password is sent to {email}" };
        }

       

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
       {

    if (request.Role == UserRole.Hod)
    {
        var hod = await _hodRepository.GetByEmailAsync(request.Email);
        if (hod == null) return null;

        if (!_passwordHasher.VerifyPassword(hod.Password,request.Password))
            return null;

                var response = _mapper.Map<LoginResponse>(hod);
                response.Role = UserRole.Hod;

                return response;
            }

    if (request.Role == UserRole.Student)
    {
        var student = await _studentRepository.GetByEmailAsync(request.Email);
        if (student == null) return null;

        if (!_passwordHasher.VerifyPassword(student.Password, request.Password))
            return null;

                var response = _mapper.Map<LoginResponse>(student);
                response.Role = UserRole.Student;

                return response;
            }

    if (request.Role == UserRole.Teacher)
    {
        var teacher = await _teacherRepository.GetByEmailAsync(request.Email);
        if (teacher == null) return null;

        if (!_passwordHasher.VerifyPassword(teacher.Password,request.Password))
            return null;

                var response = _mapper.Map<LoginResponse>(teacher);
                response.Role = UserRole.Teacher;

                return response;
            }
    if (request.Role == UserRole.Admin)
    {
        var admin = await _adminRepository.GetByEmailAsync(request.Email);
        if (admin == null) return null;
        if (!_passwordHasher.VerifyPassword(admin.Password,request.Password))
            return null;

        return _mapper.Map<LoginResponse>(admin);
    }

    return null;

}
    }
}