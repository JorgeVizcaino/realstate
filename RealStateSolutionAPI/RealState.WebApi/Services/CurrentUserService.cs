using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using RealState.Application.Common.Interfaces;

namespace RealState.WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }
        public bool IsAuthenticated { get; }
    }
}