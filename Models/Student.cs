using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Student
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is Required")]
    [MinLength(3, ErrorMessage = "Name must be atleast 3 characters")]
    [MaxLength(50, ErrorMessage = "Name cannot excedded 50 characters")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Email is Required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [MaxLength(100)]
    public string Email { get; set; }
    [Required(ErrorMessage = "Passsword is Required")]
    [MinLength(8, ErrorMessage = "Password must be atleast 8 characters")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Class is Required")]
    [ForeignKey("Class")]
    public int ClassId { get; set; }
    [MaxLength(10, ErrorMessage = "Contact Number cannot excedded 10 characters")]
    public int ContactNumber { get; set; }
    
}