using System.Collections.Generic;
using System.Linq;
using VehicleControl.CrossCutting.Filter;
using VehicleControl.Data.Base;
using VehicleControl.Data.Context;
using VehicleControl.Data.Interface;
using VehicleControl.Domain;

namespace VehicleControl.Data.Repository
{
    public class AnuncioRepository : BaseRepository<Anuncio, AnuncioFilter>, IAnuncioRepository
    {
        public AnuncioRepository(DataContext context) : base(context)
        {
        }

        public override List<Anuncio> GetAll(AnuncioFilter filter)
        {
            using (var context = GetContext())
            {
                var query = context.Set<Anuncio>().Where(w => w.Active);

                if (!string.IsNullOrWhiteSpace(filter.Term))
                    query = query.Where(w => w.Cor.Contains(filter.Term) || w.Ano.ToString() == filter.Term);

                if(filter.InitialDate.HasValue && filter.FinalDate.HasValue)
                    query = query.Where(w => w.DataVenda >= filter.InitialDate && w.DataVenda <= filter.FinalDate);

                return query.OrderBy(a => a.Date).ToList();
            }
        }
    }
}
