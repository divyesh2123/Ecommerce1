using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Database;
using Ecommerce.ViewModels;

namespace Ecommerce.Servicies.Interface
{
    public interface IUserService
    {
        /// <summary>
        /// Get All Information
        /// </summary>
        /// <returns></returns>
        List<UserViewModel> GetAllInformation();

        /// <summary>
        /// Get User Information 
        /// </summary>
        /// <returns></returns>
        UserViewModel GetUserInformation(string id);


        /// <summary>
        /// Update UserInformation
        /// </summary>
        /// <returns></returns>
        bool UpdateUserInformation(UserViewModel userViewModel,string role);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool RemoveUserInformation(string id);


        List<ApplicationRole> GetAllRoleInformation();
    }
}
