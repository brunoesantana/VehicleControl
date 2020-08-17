using System.Collections.Generic;
using System.Linq;
using VehicleControl.CrossCutting.Filter;
using VehicleControl.Data.Base;
using VehicleControl.Data.Context;
using VehicleControl.Data.Interface;
using VehicleControl.Domain;

namespace VehicleControl.Data.Repository
{
    public class ModeloRepository : BaseRepository<Modelo, ModeloFilter>, IModeloRepository
    {
        public ModeloRepository(DataContext context) : base(context)
        {
        }

        public override List<Modelo> GetAll(ModeloFilter filter)
        {
            using (var context = GetContext())
            {
                var query = context.Set<Modelo>().Where(w => w.Active);

                if (!string.IsNullOrWhiteSpace(filter.Term))
                    query = query.Where(w => w.Name.Contains(filter.Term) || w.Detail.Contains(filter.Term));

                return query.OrderBy(a => a.Name).ToList();
            }
        }
    }
}
