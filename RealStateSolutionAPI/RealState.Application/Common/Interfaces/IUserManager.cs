using System.Threading.Tasks;
using RealState.Application.Common.Models;
using RealState.Application.Login.Queries.LoginUser;

namespace RealState.Application.common.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);
        Task<Result> DeleteUserAsync(string userId);
        Task<UserAuthenticated> LoginUser(string user, string password);
    }
}