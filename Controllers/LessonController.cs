using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/lessons")]
public class LessonController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILessonService _lessonService;
    private readonly ITokenService _tokenService;

    public LessonController(UserManager<ApplicationUser> userManager,
    ILessonService lessonService, ITokenService tokenService)
    {
        _userManager = userManager;
        _lessonService = lessonService;
        _tokenService = tokenService;
    }

    [Authorize(Roles = "Manager")]
    [HttpPost("add")]
    public IActionResult Add([FromForm] LessonDataForm dataForm)
    {
        _lessonService.Add(dataForm);
        return Ok();
    }

    [Authorize(Roles = "Manager")]
    [HttpDelete("delete")]
    public IActionResult Delete(int lessonId)
    {
        _lessonService.Delete(lessonId);
        return Ok();
    }


    [Authorize(Roles = "Manager")]
    [HttpPut("edit")]
    public IActionResult Edit([FromForm] LessonDataForm lessonDataForm)
    {
        _lessonService.Edit(lessonDataForm);
        return Ok();
    }

    [Authorize]
    [HttpGet("mark/{lessonId}/{mark}")]
    public IActionResult Authorize(int lessonId, int mark)
    {
        string authHeader = Request.Headers["Authorization"];
        string token = authHeader.Substring("Bearer ".Length).Trim();
        var principal = _tokenService.ValidateToken(token);
        var email = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
        var user = _userManager.FindByEmailAsync(email);
        if (user != null)
        {
            _lessonService.Mark(user.Id, lessonId, mark);
            return Ok();
        }
        return BadRequest();
    }

    [Authorize]
    [HttpGet("addfavourite")]
    public IActionResult AddFavourite(int lessonId)
    {
        string authHeader = Request.Headers["Authorization"];
        string token = authHeader.Substring("Bearer ".Length).Trim();
        var principal = _tokenService.ValidateToken(token);
        var email = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
        var user = _userManager.FindByEmailAsync(email);
        if (user != null)
        {
            _lessonService.AddFavourite(user.Id, lessonId);
            return Ok();
        }
        return BadRequest();
    }
    [Authorize]
    [HttpGet("deletefavourite")]
    public IActionResult DeleteFavourite(int lessonId)
    {
        string authHeader = Request.Headers["Authorization"];
        string token = authHeader.Substring("Bearer ".Length).Trim();
        var principal = _tokenService.ValidateToken(token);
        var email = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
        var user = _userManager.FindByEmailAsync(email);
        if (user != null)
        {
            _lessonService.AddFavourite(user.Id, lessonId);
            return Ok();
        }
        return BadRequest();
    }

    [HttpPost("getlessonsnonauthuser")]
    public IActionResult GetLessonsNonAuthUser(List<string> tags)
    {
        return Ok(_lessonService.GetLessonsNonAuthUser(tags));
    }
    [HttpPost("getlessonsauthuser")]
    public IActionResult GetLessonsAuthUser(List<string> tags)
    {
        string authHeader = Request.Headers["Authorization"];
        string token = authHeader.Substring("Bearer ".Length).Trim();
        var principal = _tokenService.ValidateToken(token);
        var email = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
        var user = _userManager.FindByEmailAsync(email);
        if (user != null)
        {
            return Ok(_lessonService.GetLessonsAuthUser(user.Id, tags));
        }
        return BadRequest("Не авторизован");
    }
    
    [HttpGet("getlesson/{lessonId}")]
    public IActionResult GetLesson(int lessonId)
    {
        return Ok(_lessonService.GetLesson(lessonId));
    }




}