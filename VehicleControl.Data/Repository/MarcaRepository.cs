using System.Collections.Generic;
using System.Linq;
using VehicleControl.CrossCutting.Filter;
using VehicleControl.Data.Base;
using VehicleControl.Data.Context;
using VehicleControl.Data.Interface;
using VehicleControl.Domain;

namespace VehicleControl.Data.Repository
{
    public class MarcaRepository : BaseRepository<Marca, MarcaFilter>, IMarcaRepository
    {
        public MarcaRepository(DataContext context) : base(context)
        {
        }

        public override List<Marca> GetAll(MarcaFilter filter)
        {
            using (var context = GetContext())
            {
                var query = context.Set<Marca>().Where(w => w.Active);

                if (!string.IsNullOrWhiteSpace(filter.Term))
                    query = query.Where(w => w.Name.Contains(filter.Term));

                return query.OrderBy(a => a.Name).ToList();
            }
        }
    }
}
