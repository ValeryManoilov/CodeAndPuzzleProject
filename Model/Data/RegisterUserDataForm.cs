

using System.ComponentModel.DataAnnotations;

public class RegisterUserDataForm
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set;}
    [Required]
    public string DateOfBirth { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    public IFormFile? avatar { get; set; }

}