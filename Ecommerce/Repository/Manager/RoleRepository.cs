using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Database;
using Ecommerce.Repository.Interface;

namespace Ecommerce.Repository.Manager
{
    public class RoleRepository : IRoleRepository
    {
        private EcommerceDbContext Context { get; set; }

        public RoleRepository(EcommerceDbContext context)
        {
            Context = context;
        }
        public bool AddRoleInformation(string userId, string role)
        {
            bool result = false;

            Context.ApplicationUserRoles.Add(new ApplicationUserRole{RoleId = role, UserId = userId});

            if (Context.SaveChanges() > 0)
                result = true;


            return result;
        }

        public ApplicationUserRole GetUserRoleInformation(string userId)
        {
            var result = Context.ApplicationUserRoles.Where(x => x.UserId == userId).FirstOrDefault();

            return result;
        }

        public bool UpdateRoleInformation(string userId, string role)
        {
            var resultForUpdate = false;
            var result = Context.ApplicationUserRoles.Where(x => x.UserId == userId).FirstOrDefault();
            result.RoleId = role;

            if (Context.SaveChanges() > 0)
                resultForUpdate = true;


            return resultForUpdate;
        }

        public List<ApplicationRole> GetAllRoleData()
        {
            var result = Context.ApplicationRole.ToList();

            return result;
        }
    }
}
