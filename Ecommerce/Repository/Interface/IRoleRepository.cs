using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Database;

namespace Ecommerce.Repository.Interface
{
    public interface IRoleRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        ApplicationUserRole GetUserRoleInformation(string userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        bool UpdateRoleInformation(string userId, string role);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        bool AddRoleInformation(string userId, string role);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ApplicationRole> GetAllRoleData();
    }
}
