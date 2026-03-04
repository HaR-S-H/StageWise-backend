using System.ComponentModel.DataAnnotations;
using StageWise.Helpers.Enums;

namespace StageWise.Dtos.Auth.Response
{
    public class LoginResponse
    {  
        public required int Id { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required UserRole Role { get; set; }

    }
}