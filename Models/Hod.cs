using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
public class Hod
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is Required")]
    [MinLength(3, ErrorMessage = "Name must be atleast 3 characters")]
    [MaxLength(50, ErrorMessage = "Name cannot be more than 50 characters")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Email is Required")]
    [EmailAddress(ErrorMessage = "Invalid Email")]
    [MaxLength(50, ErrorMessage = "Email cannot be more than 50 characters")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Passsword is Required")]
    [MinLength(8, ErrorMessage = "Password must be atleast 8 characters")]
    [MaxLength(15, ErrorMessage = "Password cannot be more than 15 characters")]
    public string Password { get; set; }
    [MinLength(10, ErrorMessage = "Contact Number must be 10 characters")]
    [MaxLength(10, ErrorMessage = "Contact Number cannot be more than 10 characters")]
    public string ContactNumber { get; set; }
    [Required(ErrorMessage = "Department is Required")]
    public Department Department { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Block Number must be greater than 0")]
    public int BlockNumber { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Cabin Number must be greater than 0")]
    public int CabinNumber { get; set; }
    [Required(ErrorMessage = "Course is Required")]
    public string Course{ get; set; }


}