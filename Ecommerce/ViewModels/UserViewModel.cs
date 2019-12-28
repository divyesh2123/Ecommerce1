using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.ViewModels
{
    public class UserViewModel
    {
        public  string UserName { get; set; }

        public  string Email { get; set; }

         public  string Name { get; set; }

        /// <summary>
        /// Contact of User
        /// </summary>
        public string ContactNumber { get; set; }

        /// <summary>
        /// Address1 of User
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Address2 of User
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// City of User
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State of User
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// ZipCode of User
        /// </summary>
        public string Zipcode { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public  string Role { get; set; }

        /// <summary>
        /// Status
        /// </summary>

        public string Status
        {
            get
            {
                if (IsActive == true)
                {
                    return "Active";
                }
                else
                {
                    return "InActive";
                }
            }


        }

        /// <summary>
        /// IsActive Information
        /// </summary>
        public bool IsActive { get; set; }


       public  string RoleId { get; set; }


        public  List<SelectListItem> Data { get; set; }

        public  string Id { get; set; }

        public  string Password { get; set; }

        public  string ConfirmPassword { get; set; }

    }
}
