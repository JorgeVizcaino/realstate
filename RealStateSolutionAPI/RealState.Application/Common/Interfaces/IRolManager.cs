using System.Threading.Tasks;
using RealState.Application.Common.Models;

namespace RealState.Application.common.Interfaces
{
    public interface IRolManager
    {
        Task<(Result Result, string rolName)> CreateRolAsync(string rolName);

        Task<Result> DeleteRolAsync(string rolName);
        //Task<RolAspNet> FindRolByName(string rolName);
    }
}