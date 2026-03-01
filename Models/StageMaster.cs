using System.ComponentModel.DataAnnotations;
namespace StageWise.Models{

public class StageMaster
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
}  
  
}

