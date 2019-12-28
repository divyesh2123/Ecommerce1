using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.ViewModels;

namespace Ecommerce.Servicies.Interface
{
   public interface IUnitService
    {
        List<UnitViewModel> GetUnitInformation();

        UnitViewModel GetUnitInformation(int id);

        bool AddUnit(UnitViewModel unitViewModel);

        bool UpdateUnit(UnitViewModel unitViewModel);

        bool RemoveUnit(int Id);
    }
}
