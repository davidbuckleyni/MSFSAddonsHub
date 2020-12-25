using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSFSAddonsHub.Dal.Models;
using MSFSAddonsHub.WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSFSAddonsHub.WebApi.Controllers
{
    public class UsersController  :ControllerBase {
        private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    private void setTokenCookie(string token)
    {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(7)
        };
        Response.Cookies.Append("refreshToken", token, cookieOptions);
    }

    private string ipAddress()
    {
        if (Request.Headers.ContainsKey("X-Forwarded-For"))
            return Request.Headers["X-Forwarded-For"];
        else
            return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    }


    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody] AuthenticateRequest model)
    {

        var response = _userService.Authenticate(model, ipAddress());

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        setTokenCookie(response.JwtToken);

        return Ok(response);
    }
}
}
