

using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AvatarPath { get; set; }
}