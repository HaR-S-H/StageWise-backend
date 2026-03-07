using System.Text.Json;
using AutoMapper;
using StageWise.Dtos.Hod;
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
        private readonly IS3Service _s3Service;
        public HodService(ICurrentUserService currentUserService,IHodRepository hodRepository,IPasswordHasher passwordHasher,IMessageQueue messageQueue,IMapper mapper,IS3Service s3Service)
        {
            _currentUser = currentUserService;
            _hodRepository = hodRepository;
            _passwordHasher = passwordHasher;
            _messageQueue = messageQueue;
            _mapper = mapper;
            _s3Service = s3Service;
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

        public async Task<DeleteHodResponse> DeleteHodAsync(DeleteHodRequest request)
        {
           var hod=await _hodRepository.GetByIdAsync(request.Id);
            if (hod == null) throw new AppException("Hod not found", 404);
            await _hodRepository.DeleteAsync(hod);
            await _hodRepository.SaveAsync();
            return new DeleteHodResponse { Success = true, Message = "Hod deleted successfully" };
        }

        public async Task<GetHodResponse> GetHodAsync()
        {
            var hod = await _hodRepository.GetByEmailAsync(_currentUser.Email);
            if (hod == null) throw new AppException("Hod not found", 404);
            return _mapper.Map<GetHodResponse>(hod);
        }

        public async Task<List<GetHodResponse>> GetHodsAsync()
        {
            var hods=await _hodRepository.GetAllAsync();
            if (hods.Count == 0) throw new AppException("No hods found", 404);
            return _mapper.Map<List<GetHodResponse>>(hods);
        }

        public async Task<UpdateHodResponse> UpdateHodAsync(UpdateHodRequest request)
        {
            var hod = await _hodRepository.GetByIdAsync(request.Id);

            if (hod == null) throw new AppException("Hod not found", 404);

            if (request.Name != null)
                hod.Name = request.Name;

            if (request.Avatar != null)
            {
                var avatarUrl = await _s3Service.UploadFileAsync(request.Avatar);
                hod.Avatar = avatarUrl;
            }

            if (request.BlockNumber != null)
                hod.BlockNumber = request.BlockNumber;

            if (request.CabinNumber != null)
                hod.CabinNumber = request.CabinNumber;

            if (request.ContactNumber != null)
                hod.ContactNumber = request.ContactNumber;

            await _hodRepository.UpdateAsync(hod);
            await _hodRepository.SaveAsync();

            return new UpdateHodResponse
            {
                Success = true,
                Message = $"Update Hod {request.Name} Successfully."
            };
        }
    }
}