using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RealState.Application.common.Interfaces;
using RealState.Application.Common.Interfaces;
using RealState.Application.Main.UserHandler;
using RealState.Application.Notifications.Models;
using RealState.Domain.Entities;
using RealState.Infrastructure.AppSettings;
using RealState.Infrastructure.Identity;
using RealState.WebApi.Common;

namespace RealState.WebApi.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
    {
        private readonly IEmailSender _emailSender;
        private readonly IUserManager _iLoginUserManager;
        private readonly INotificationService _notification;
        private readonly IOptions<AppSettings> _options;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IOptions<AppSettings> options
            , IUserManager iLoginUserManager
            , UserManager<ApplicationUser> userManager
            , IEmailSender emailSender
            , INotificationService notificationService
        )
        {
            _options = options;
            _iLoginUserManager = iLoginUserManager;
            _userManager = userManager;
            _emailSender = emailSender;
            _notification = notificationService;
        }

        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public async Task<ActionResult<HttpResponseMessage>> CreateUser([FromBody] UserCreationCommand command)
        {
            if (command == null)
                return BadRequest("User cannot be null");
            command.UserCreates = User.Identity.Name;
            var newUser = new ApplicationUser();
            newUser.UserName = command.Email;
            newUser.FirstName = command.FirstName;
            newUser.LastName = command.LastName;
            newUser.Email = command.Email;
            var userIdentity = await _userManager.CreateAsync(newUser, command.PassWord);

            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            if (!userIdentity.Succeeded)
            {
                var errorMessage = "";
                foreach (var error in userIdentity.Errors) errorMessage += error.Description + " <br> ";
                return BadRequest(new {message = errorMessage});
            }

            var to = new List<string>();
            to.Add(newUser.Email);
            var token = HttpUtility.UrlEncode(await _userManager.GenerateEmailConfirmationTokenAsync(newUser));
            var confirmationLink = "<center> Hello " + newUser.FirstName + " " + newUser.LastName +
                                   " welcome to DevNet, click " +
                                   "<a href=\'" + _options.Value.UrlBaseWeb + "/login/confirmationEmail?code="
                                   + token + "&email=" + newUser.Email + "'> here </a>" +
                                   "to get access.</center>";
            var message = new Message {Body = confirmationLink, To = to, Subject = "DevNet Email Confirmation"};
            await _notification.SendEmailHTMLAsync(message);
            response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent("Success");
            return Ok(response);
        }

        [HttpPost("ConfirmEmail")]
        [AllowAnonymous]
        public async Task<ActionResult<HttpResponseMessage>> ConfirmEmail(UserCreationCommand command)
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var user = await _userManager.FindByEmailAsync(command.Email);
            if (user == null) response.Content = new StringContent("User confirmation failed");

            var result = await _userManager.ConfirmEmailAsync(user, command.Token);
            if (result.Succeeded)
            {
                response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent("Success");
            }

            return response;
        }


        [AllowAnonymous]
        [HttpGet("forgotPassword/{email}")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return BadRequest(new {message = "The selected email doesn't exist"});

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var to = new List<string>();
            to.Add(email);
            var confirmationLink = "<center> Hello " + user.FirstName + " " + user.LastName +
                                   ", you can recover your account password by entering" +
                                   "<a href=\"" + _options.Value.UrlBaseWeb + "/login/recoverP" +
                                   "?email=" + user.Email + "&code=" + HttpUtility.UrlEncode(code) + "\" > here</a>" +
                                   ".</center>";
            var message = new Message {Body = confirmationLink, To = to, Subject = "DevNet Account Recovery"};
            await _notification.SendEmailHTMLAsync(message);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent("Email Successfully sent");
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("recoverPassword")]
        public async Task<IActionResult> RecoveryPassword([FromBody] RecoverPassword userRec)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(userRec.Email);
                if (user == null)
                    return BadRequest(new {message = "The selected email doesn't exist"});
                var code = await _userManager.ResetPasswordAsync(user, userRec.code, userRec.NewPassword);
                if (code.Succeeded)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("Password successfully updated");
                    return Ok(response);
                }

                foreach (var err in code.Errors)
                    if (err.Code.Equals("InvalidToken"))
                        return BadRequest(new {message = "Invalid Token"});

                return BadRequest(new {message = code.Errors});
            }
            catch (Exception e)
            {
                var ex = e;
                return BadRequest();
            }
        }
    }
}