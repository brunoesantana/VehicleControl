using System;
using System.Collections.Generic;
using VehicleControl.CrossCutting.Filter.Base;
using VehicleControl.Data.Context;

namespace VehicleControl.Data.Interface.Base
{
    public interface IRepositoryBase<T, TFilter> where T : class where TFilter : BaseFilter
    {
        Guid Create(T dto);

        T Update(T dto);

        void Remove(Guid id);

        T Find(Guid id);

        List<T> GetAll(TFilter filter);
    }
}
