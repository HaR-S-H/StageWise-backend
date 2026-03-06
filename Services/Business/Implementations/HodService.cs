using System.Text.Json;
using AutoMapper;
using StageWise.Dtos.Hod.Request;
using StageWise.Dtos.Hod.Response;
using StageWise.Helpers;
using StageWise.Helpers.Exceptions;
using StageWise.Helpers.Interfaces;
using StageWise.Models;
using StageWise.Repositories.Interfaces;
using StageWise.Services.Business.Interfaces;
using StageWise.Services.Infrastructure.Interfaces;

namespace StageWise.Services.Business.Implementations
{
    public class HodService : IHodService
    {
        private readonly ICurrentUserService _currentUser;
        private readonly IHodRepository _hodRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMessageQueue _messageQueue;
        private readonly IMapper _mapper;
        public HodService(ICurrentUserService currentUserService,IHodRepository hodRepository,IPasswordHasher passwordHasher,IMessageQueue messageQueue,IMapper mapper)
        {
            _currentUser = currentUserService;
            _hodRepository = hodRepository;
            _passwordHasher = passwordHasher;
            _messageQueue = messageQueue;
            _mapper = mapper;
        }

        public async Task<CreateHodResponse> CreateHodAsync(CreateHodRequest request)
        {
            var existingHod = await _hodRepository.GetByEmailAsync(request.Email);

            if (existingHod != null)
                throw new AppException("hod already exists", 409);

            var password = PasswordGenerator.GeneratePassword();

            var hashedPassword = _passwordHasher.HashPassword(password);

            var hod = _mapper.Map<Hod>(request);
            hod.Password = hashedPassword;
            await _hodRepository.AddAsync(hod);
            await _hodRepository.SaveAsync();

            var emailMessage = new
            {
                To = request.Email,
                Subject = "Hod Account Created",
                Body = $"Hello {request.Name}, your hod password is: {password}"
            };

            var message = JsonSerializer.Serialize(emailMessage);

            await _messageQueue.Publish("EmailQueue", message);

            return new CreateHodResponse
            {
                Success = true,
                Message = "Hod created successfully. Password sent to email."
            };
        }

        public async Task<GetHodResponse> GetHodAsync()
        {
            var hod = await _hodRepository.GetByEmailAsync(_currentUser.Email);
            if (hod == null) throw new AppException("Hod not found", 404);
            return _mapper.Map<GetHodResponse>(hod);
        }
    }
}