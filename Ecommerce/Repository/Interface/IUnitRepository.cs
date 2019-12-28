using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Database;

namespace Ecommerce.Repository.Interface
{
   public interface IUnitRepository
    {
        List<Unit> GetUnitInformation();

        bool AddUnit(Unit unit);

        bool UpdateUnit(Unit unit);

        bool RemoveUnit(int Id);

        Unit GetUnit(int id);
    }
}
