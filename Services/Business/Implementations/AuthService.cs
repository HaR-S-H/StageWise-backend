using StageWise.Dtos.Auth.Response;
using StageWise.Helpers.Enums;
using StageWise.Helpers.Interfaces;
using StageWise.Repositories.Interfaces;
using StageWise.Dtos.Auth.Request;
using AutoMapper;
using StageWise.Services.Business.Interfaces;

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

        public AuthService(IPasswordHasher passwordHasher, IHodRepository hodRepository, IStudentRepository studentRepository, ITeacherRepository teacherRepository,IMapper mapper,IAdminRepository adminRepository)
        {
            _passwordHasher = passwordHasher;
            _hodRepository = hodRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _adminRepository = adminRepository;
            _mapper = mapper;

        }

       public async Task<LoginResponse?> LoginAsync(LoginRequest request)
       {

    if (request.Role == UserRole.Hod)
    {
        var hod = await _hodRepository.GetByEmailAsync(request.Email);
        if (hod == null) return null;

        if (!_passwordHasher.VerifyPassword(request.Password, hod.Password))
            return null;

        return _mapper.Map<LoginResponse>(hod);
    }

    if (request.Role == UserRole.Student)
    {
        var student = await _studentRepository.GetByEmailAsync(request.Email);
        if (student == null) return null;

        if (!_passwordHasher.VerifyPassword(request.Password, student.Password))
            return null;

        return _mapper.Map<LoginResponse>(student);
    }

    if (request.Role == UserRole.Teacher)
    {
        var teacher = await _teacherRepository.GetByEmailAsync(request.Email);
        if (teacher == null) return null;

        if (!_passwordHasher.VerifyPassword(request.Password, teacher.Password))
            return null;

        return _mapper.Map<LoginResponse>(teacher);
    }
    if (request.Role == UserRole.Admin)
    {
        var admin = await _adminRepository.GetByEmailAsync(request.Email);
        if (admin == null) return null;

        if (!_passwordHasher.VerifyPassword(request.Password,admin.Password))
            return null;

        return _mapper.Map<LoginResponse>(admin);
    }

    return null;

}
    }
}