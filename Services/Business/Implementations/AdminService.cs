using System.Text.Json;
using AutoMapper;
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
        private readonly ICurrentUserService _currentUser;
        private readonly IAdminRepository _adminRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMessageQueue _messageQueue;
        private readonly IMapper _mapper;
        public AdminService(IAdminRepository adminRepository, IPasswordHasher passwordHasher, IMessageQueue messageQueue,ICurrentUserService currentUser,IMapper mapper)
        {

            _adminRepository = adminRepository;
            _passwordHasher = passwordHasher;
            _messageQueue = messageQueue;
            _currentUser = currentUser;
            _mapper = mapper;
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

        public async Task<GetAdminResponse> GetAdminAsync()
        {
            var admin = await _adminRepository.GetByEmailAsync(_currentUser.Email);
            if (admin == null) throw new AppException("Admin not found", 404);
            return _mapper.Map<GetAdminResponse>(admin);
        }
        public async Task<List<GetAdminResponse>> GetAdminsAsync()
        {
            var admins = await _adminRepository.GetAllAsync();
            if(admins.Count==0) throw new AppException("No admins found", 404);
            return _mapper.Map<List<GetAdminResponse>>(admins);
        }
    }
}