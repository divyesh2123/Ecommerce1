using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Database;
using Ecommerce.Repository.Interface;

namespace Ecommerce.Repository.Manager
{
    public class UserRepository : IUserRepository
    {
        private EcommerceDbContext Context { get; set; }

        public UserRepository(EcommerceDbContext context)
        {
            Context = context;
        }
        public bool AddUser(ApplicationUser applicationUser)
        {
            bool result = false;

            Context.Users.Add(applicationUser);

            if (Context.SaveChanges() > 0)
                result = true;


            return result;
        }

        public ApplicationUser GetUser(string id)
        {
            var result = Context.Users.Where(x => x.Id == id).FirstOrDefault();
            return result;
        }

        public List<ApplicationUser> GetUserInformation()
        {
            var result = Context.Users.Where(x=>x.IsDelete == true).ToList();
            return result;
        }

        public bool RemoveUser(string id)
        {
            var result = Context.Users.Where(x => x.Id == id).FirstOrDefault();
            result.IsDelete = true;
            if (Context.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public bool UpdateUser(ApplicationUser applicationUser, string role)
        {
            bool result = false;
            this.Context.ApplicationUser.Attach(applicationUser);
            this.Context.Entry(applicationUser).Property(p => p.IsActive).IsModified = true;

            var roleInformation = Context.UserRoles.Where(x => x.UserId == applicationUser.Id).FirstOrDefault();

            var applicationRole = Context.ApplicationRole.Where(x => x.Name == role).FirstOrDefault();

            roleInformation.RoleId = applicationRole.Id;

            if (Context.SaveChanges() > 0)
                result = true;

            return result;
        }
    }
}
