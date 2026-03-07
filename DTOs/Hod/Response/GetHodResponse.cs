using System.ComponentModel.DataAnnotations;
using StageWise.Helpers.Enums;

namespace StageWise.Dtos.Hod.Response
{
    public class GetHodResponse
    {   public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public UserRole Role { get; set; }
        public string? Avatar { get; set; }
        public required string ContactNumber { get; set; }
        public required string CabinNumber { get; set; }
        public required string BlockNumber { get; set; }
    }
}