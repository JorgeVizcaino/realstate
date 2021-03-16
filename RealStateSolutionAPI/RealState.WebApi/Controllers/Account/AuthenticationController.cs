using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RealState.Application.common.Interfaces;
using RealState.Domain.Entities;
using RealState.Infrastructure.AppSettings;
using RealState.Infrastructure.Identity;
using RealState.WebApi.Common;

namespace RealState.WebApi.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ApiController
    {
        private readonly IUserManager _iLoginUserManager;
        private readonly IOptions<AppSettings> _options;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationController(IOptions<AppSettings> options
            , IUserManager iLoginUserManager
            , UserManager<ApplicationUser> userManager)
        {
            _options = options;
            _iLoginUserManager = iLoginUserManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginUser userParam)
        {
                var result = await _iLoginUserManager.LoginUser(userParam.UserName, userParam.Password);
                if (result == null) return BadRequest(new { message = "Invalid username or password" });

                var UserResult = await _userManager.FindByNameAsync(userParam.UserName.Trim());
                var rolesUser = await _userManager.GetRolesAsync(UserResult);

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_options.Value.AppAuthenticationSettings.SecretString);
                var issuerKey = _options.Value.AppAuthenticationSettings.UrlGeneraToken;
                var audienceToken = _options.Value.AppAuthenticationSettings.AudienceToken;
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = issuerKey,
                    Audience = audienceToken,
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub, result.UserName),
                    new Claim(JwtRegisteredClaimNames.Sid, UserResult.Id),
                    new Claim(JwtRegisteredClaimNames.Email, result.Email),
                    new Claim(ClaimTypes.Role, string.Join(',', rolesUser))
                }),
                    Expires = DateTime.UtcNow.AddDays(6),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                result.Token = tokenHandler.WriteToken(token);
                return Ok(result);
           
        }
    }
}