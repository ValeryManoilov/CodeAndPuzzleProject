using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly IEmailService _emailService;
    private readonly ITokenService _tokenService;
    private readonly EmailAnswerPatterns _emailAnswerPatterns = new EmailAnswerPatterns();

    public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
     RoleManager<ApplicationRole> roleManager, IEmailService emailService, ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _emailService = emailService;
        _tokenService = tokenService;
    }


    [HttpPost("adduser")]
    public async Task<IActionResult> CreateUser([FromForm] RegisterUserDataForm userForm)
{
    var user = new ApplicationUser{
        UserName = userForm.UserName,
        FirstName = userForm.FirstName,
        LastName = userForm.LastName,
        DateOfBirth = userForm.DateOfBirth,
        AvatarPath = "default.png",
        Email = userForm.Email};
        if (userForm.avatar != null)
        {
            string avatarPath = $"{Guid.NewGuid()}_{userForm.avatar.FileName}";
            user.AvatarPath = $"Content/Avatars/{avatarPath}";
            using (var filestream = new FileStream(user.AvatarPath, FileMode.Create))
            {
                userForm.avatar.CopyTo(filestream);
            }
        }

    var result = await _userManager.CreateAsync(user, userForm.Password);
    if (result.Succeeded)
    {
        _signInManager.SignInAsync(user, false).Wait();
        await _userManager.AddToRoleAsync(user, "Member");

        string subject = "Регистрация";
        await _emailService.SendEmailAsync(userForm.Email, subject,
        _emailAnswerPatterns.emailAnswerPatterns[subject], false);

        return Ok(new {
            token = _tokenService.CreateToken(user.Email, ["Member"]),
            userRole = await _userManager.GetRolesAsync(user)});
    }
    else
    {
        Console.WriteLine(result);
        return BadRequest();
    }
}


    [HttpGet("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        ApplicationUser user = await _userManager.FindByEmailAsync(email);
        if (user != null)
        {
            var result = _signInManager.PasswordSignInAsync(user.UserName, password, false, false).Result;
            if (result.Succeeded)
            {
                
                IList<string> userRoles = await _userManager.GetRolesAsync(user);

                string subject = "Вход в аккаунт";
                await _emailService.SendEmailAsync(email, subject,
                _emailAnswerPatterns.emailAnswerPatterns[subject] , false);

                return Ok(new {
                    token = _tokenService.CreateToken(email, userRoles.ToList()),
                    userRole = userRoles
                    });
            }
        }
        return BadRequest("Неправильная почта или пароль");
    }
    
    [HttpGet("logout")]
    public IActionResult Logout()
    {
        _signInManager.SignOutAsync().Wait();
        return Ok(new {token = ""});
        
    }

    [Authorize]
    [HttpGet("userinfo")]
    public async Task<IActionResult> GetUserInfo()
    {
        string authHeader = Request.Headers["Authorization"];
        string token = authHeader.Substring("Bearer ".Length).Trim();
        var principal = _tokenService.ValidateToken(token);
        
        string userEmail = principal.Claims.First(c => c.Type == ClaimTypes.Email).Value;
        ApplicationUser user = await _userManager.FindByEmailAsync(userEmail);
        if (user != null)
        {
            return Ok(new {data = new {
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                UserName = user.UserName,
                Email = user.Email,
                AvatarPath = user.AvatarPath
            },
            userRole = await _userManager.GetRolesAsync(user)});
        }
        return BadRequest();
    }

    [Authorize]
    [HttpPut("updateuserinfo")]
    public async Task<IActionResult> UpdateUserInfo([FromForm] UpdateUserDataForm userForm)
    {
        var user = await _userManager.FindByEmailAsync(userForm.Email);
        user.FirstName = userForm.FirstName;
        user.LastName = userForm.LastName;
        user.UserName = userForm.UserName;
        user.DateOfBirth = userForm.DateOfBirth;
        if (userForm.avatar != null)
        {
            var oldAvatarPath = user.AvatarPath;
            System.IO.File.Delete(oldAvatarPath);
        }
        string newAvatarPath = $"{Guid.NewGuid()}_{userForm.avatar.FileName}";
        user.AvatarPath = $"Content/Avatars/{newAvatarPath}";
        using (var filestream = new FileStream(user.AvatarPath, FileMode.Create))
        {
            userForm.avatar.CopyTo(filestream);
        }
        await _userManager.UpdateAsync(user);
        
        string subject = "Изменены личные данные";
        await _emailService.SendEmailAsync(user.Email,subject, 
            _emailAnswerPatterns.emailAnswerPatterns[subject], false);

        return Ok();
    }






    [HttpGet("firstinitialize")]
    public IActionResult FirstInitialize()
    {
        if (!_roleManager.RoleExistsAsync("Admin").Result)
        {
            var adminRole = new ApplicationRole{Name = "Admin"};
            var roleCreatingResult = _roleManager.CreateAsync(adminRole).Result;
            if (roleCreatingResult.Succeeded)
            {
                var adminUser = new ApplicationUser{
                    FirstName = "Санджар",
                    LastName = "Сатлыков",
                    DateOfBirth = "10.10.2007",
                    AvatarPath = "default.png",
                    UserName = "satlykovs@gmail.com", 
                    Email = "satlykovs@gmail.com"};
                var adminCreatingResult = _userManager.CreateAsync(adminUser, "Sanjar10102007!").Result;
                if (adminCreatingResult.Succeeded)
                {
                    var addingResult = _userManager.AddToRoleAsync(adminUser, "Admin").Result;
                    if (addingResult.Succeeded)
                    {
                        return Ok();
                    }
                }
            }
        }
        return BadRequest();
    }

}
