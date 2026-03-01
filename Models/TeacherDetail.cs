using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StageWise.Models{


public class TeacherDetail
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }

    public string? CabinNumber { get; set; }

    public string? BlockNumber { get; set; }
}

}