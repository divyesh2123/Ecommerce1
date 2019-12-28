using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Database;

namespace Ecommerce.Repository.Interface
{
    public interface IUserRepository
    {
        List<ApplicationUser> GetUserInformation();

        bool AddUser(ApplicationUser applicationUser);

        bool UpdateUser(ApplicationUser applicationUser, string role);

        bool RemoveUser(string id);

        ApplicationUser GetUser(string id);
    }
}
