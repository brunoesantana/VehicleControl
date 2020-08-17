using System;
using System.Collections.Generic;
using VehicleControl.CrossCutting.Filter.Base;

namespace VehicleControl.Business.Interface.Base
{
    public interface IServiceBase<T, TFilter> where T : class where TFilter : BaseFilter
    {
        Guid Create(T dto);

        T Update(T dto);

        void Remove(Guid id);
        T Find(Guid id);

        List<T> GetAll(TFilter filter);
    }
}
