using System.Text.Json;
using StageWise.Dtos.Admin.Request;
using StageWise.Dtos.Admin.Response;
using StageWise.Helpers;
using StageWise.Helpers.Exceptions;
using StageWise.Helpers.Interfaces;
using StageWise.Models;
using StageWise.Repositories.Interfaces;
using StageWise.Services.Business.Interfaces;
using StageWise.Services.Infrastructure.Interfaces;

namespace StageWise.Services.Business.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMessageQueue _messageQueue;
        public AdminService(IAdminRepository adminRepository, IPasswordHasher passwordHasher, IMessageQueue messageQueue)
        {

            _adminRepository = adminRepository;
            _passwordHasher = passwordHasher;
            _messageQueue = messageQueue;

        }
       public async Task<CreateAdminResponse> CreateAdminAsync(CreateAdminRequest request)
        {
            var existingAdmin = await _adminRepository.GetByEmailAsync(request.Email);

            if (existingAdmin != null)
                throw new AppException("Admin already exists", 409);

            var password = PasswordGenerator.GeneratePassword();

            var hashedPassword = _passwordHasher.HashPassword(password);

            var admin = new Admin
            {
                Name = request.Name,
                Email = request.Email,
                Password = hashedPassword
            };

            await _adminRepository.AddAsync(admin);
            await _adminRepository.SaveAsync();

            var emailMessage = new
            {
                To = request.Email,
                Subject = "Admin Account Created",
                Body = $"Hello {request.Name}, your admin password is: {password}"
            };

            var message = JsonSerializer.Serialize(emailMessage);

            // 6️⃣ Send message to RabbitMQ
            await _messageQueue.Publish("EmailQueue", message);

            return new CreateAdminResponse
            {
                Success = true,
                Message = "Admin created successfully. Password sent to email."
            };
        }

        
    }
}