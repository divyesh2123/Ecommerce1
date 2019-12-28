using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Database;
using Ecommerce.Repository.Interface;
using Ecommerce.Servicies.Interface;
using Ecommerce.ViewModels;

namespace Ecommerce.Servicies.Manager
{
    public class UnitService : IUnitService
    {
        private IUnitRepository UnitRepository { get; set; }

        private IMapper Mapper { get; set; }

        public UnitService(IUnitRepository unitRepository, IMapper mapper)
        {
            UnitRepository = unitRepository;

            Mapper = mapper;
        }
        public bool AddUnit(UnitViewModel unitViewModel)
        {
            var model = Mapper.Map<Unit>(unitViewModel);
            return UnitRepository.AddUnit(model);
        }

        public List<UnitViewModel> GetUnitInformation()
        {
            var unitResult = UnitRepository.GetUnitInformation();
            var model = Mapper.Map<List<UnitViewModel>>(unitResult);
            return model;
        }

        public UnitViewModel GetUnitInformation(int id)
        {
            var model = UnitRepository.GetUnit(id);

            var result = Mapper.Map<UnitViewModel>(model);

            return result;
        }

        public bool RemoveUnit(int Id)
        {
            return UnitRepository.RemoveUnit(Id);
        }

        public bool UpdateUnit(UnitViewModel unitViewModel)
        {
            var model = Mapper.Map<Unit>(unitViewModel);
            return UnitRepository.UpdateUnit(model);
        }
    }
}
