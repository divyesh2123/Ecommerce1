using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Controllers;
using Ecommerce.Database;
using Ecommerce.Repository.Interface;
using Ecommerce.Servicies.Interface;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Servicies.Manager
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IEmailSender _email;

        private readonly IMapper _mapper;

        private readonly IRoleRepository _roleRepository;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly Servicies.Interface.IEmailSender _emailSender;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper,
            IRoleRepository roleRepository,
            UserManager<ApplicationUser> usermanager,
            Servicies.Interface.IEmailSender emailSender

            )
        {
            _userRepository = userRepository;

            _mapper = mapper;

            _roleRepository = roleRepository;

            _userManager = usermanager;

            _emailSender = emailSender;

        }
        public List<UserViewModel> GetAllInformation()
        {
          var result = _userRepository.GetUserInformation();
           var model = _mapper.Map<List<UserViewModel>>(result);
            return model;
           
        }

        public UserViewModel GetUserInformation(string id)
        {
            var userViewModel = _userRepository.GetUser(id);
            var model = _mapper.Map<UserViewModel>(userViewModel);
            return model;
        }

       
       
        public bool UpdateUserInformation(UserViewModel userViewModel, string role)
        {
            var model = _mapper.Map<ApplicationUser>(userViewModel);

      
            return _userRepository.UpdateUser(model,role);
        }

        public bool RemoveUserInformation(string id)
        {
            return _userRepository.RemoveUser(id);
        }


        public List<ApplicationRole> GetAllRoleInformation()
        {
            return _roleRepository.GetAllRoleData();
        }





    }
}
