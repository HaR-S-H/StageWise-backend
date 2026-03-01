using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StageWise.Models{

  public class Department
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; }

    public int HodId { get; set; }

    [ForeignKey(nameof(HodId))]
    public User HOD { get; set; }
}
  
  
}

