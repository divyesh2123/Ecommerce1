using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Database;
using Ecommerce.ViewModels;

namespace Ecommerce.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryVieWModel, Category>();
            CreateMap<Category, CategoryVieWModel>();
            CreateMap<Unit, UnitViewModel>();
            CreateMap<UnitViewModel, Unit>();
            CreateMap<ApplicationUser, UserViewModel>();
            CreateMap<UserViewModel, ApplicationUser>();
        }
    }
}
