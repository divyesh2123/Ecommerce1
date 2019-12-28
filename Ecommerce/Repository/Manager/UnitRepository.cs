using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Database;
using Ecommerce.Repository.Interface;

namespace Ecommerce.Repository.Manager
{
    public class UnitRepository : IUnitRepository
    {
        private EcommerceDbContext Context { get; set; }

        public UnitRepository(EcommerceDbContext context)
        {
            Context = context;
        }
        public bool AddUnit(Unit unit)
        {
            bool result = false;

            Context.Unit.Add(unit);

            if (Context.SaveChanges() > 0)
                result = true;


            return result;
        }

        public Unit GetUnit(int id)
        {
            var result = Context.Unit.Where(x => x.Id == id).FirstOrDefault();
            return result;
        }

        public List<Unit> GetUnitInformation()
        {
            return Context.Unit.ToList();
        }

        public bool RemoveUnit(int Id)
        {
            bool result = false;
            var dataUnit = Context.Unit.Where(x => x.Id == Id).FirstOrDefault();
            Context.Remove(dataUnit);
            if (Context.SaveChanges() > 0)
                result = true;

            return result;
        }

        public bool UpdateUnit(Unit unit)
        {
            bool result = false;
            this.Context.Unit.Attach(unit);
            this.Context.Entry(unit).Property(p => p.UnitName).IsModified = true;

            if (Context.SaveChanges() > 0)
                result = true;

            return result;
        }
    }
}
