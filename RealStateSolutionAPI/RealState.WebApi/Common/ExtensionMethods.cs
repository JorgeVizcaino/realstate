using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using RealState.Infrastructure.Identity;

namespace RealState.WebApi.Common
{
    public static class ExtensionMethods
    {


        /// <summary>
        ///     User ID
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string getUserId(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return null;

            var currentUser = user;
            return currentUser.FindFirst("sid").Value;
        }
        public static async Task<IEnumerable<T1>> SelectManyAsync<T, T1>(this IEnumerable<T> enumeration, Func<T, Task<IEnumerable<T1>>> func)
        {
            return (await Task.WhenAll(enumeration.Select(func))).SelectMany(s => s);
        }
    }
}