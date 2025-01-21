using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineCinema.Domain;
using OnlineCinema.Domain.Entities;
using OnlineCinema.Mvc.Models.ViewModels.Home;

namespace OnlineCinema.Mvc.Controllers;

public class AccountController : BaseMvcController
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    public AccountController(IMapper mapper, AppDbContext context, SignInManager<User> signInManager, UserManager<User> userManager) : base(mapper, context)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginViewModel input)
    {
        if (!string.IsNullOrWhiteSpace(input.Email))
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == input.Email);
            var result = await _signInManager.CheckPasswordSignInAsync(user, input.Password, false);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);
                return Ok(new { Name = user.Name });
            }
        }

        if (!string.IsNullOrWhiteSpace(input.Phone))
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == input.Phone);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(input.Email, input.Password, false, false);
                if (result.Succeeded)
                {
                    return Ok(new { Name = user.Name });
                }
            }
        }

        return BadRequest("Неправильный логин и/или пароль");
    }

    [HttpPost]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterViewModel input)
    {
        var user = Mapper.Map<User>(input);

        user.UserName = input.Email;
        try
        {
            var result = await _userManager.CreateAsync(user, input.Password);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);

        }
        catch (Exception ex)
        {

            throw;
        }


    }
    [Route("lk")]
    public async Task<IActionResult> PersonalAccount()
    {

        return View("PersonalAccount");
    }
}