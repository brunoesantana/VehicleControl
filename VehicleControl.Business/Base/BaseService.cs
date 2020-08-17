using System;
using System.Collections.Generic;
using VehicleControl.Business.Interface.Base;
using VehicleControl.CrossCutting.Exceptions;
using VehicleControl.CrossCutting.Filter.Base;
using VehicleControl.Data.Interface.Base;

namespace VehicleControl.Business.Base
{
    public class BaseService<T, TFilter> : IServiceBase<T, TFilter> where T : class where TFilter : BaseFilter
    {
        protected readonly IRepositoryBase<T, TFilter> Repository;

        public BaseService(IRepositoryBase<T, TFilter> repository)
        {
            Repository = repository;
        }

        public virtual Guid Create(T dto)
        {
            return Repository.Create(dto);
        }

        public virtual T Update(T dto)
        {
            return Repository.Update(dto);
        }

        public virtual void Remove(Guid id)
        {
            if (Find(id) == null)
                throw new NotFoundException();

            Repository.Remove(id);
        }

        public virtual T Find(Guid id)
        {
            return Repository.Find(id) ?? throw new NotFoundException();
        }

        public virtual List<T> GetAll(TFilter filter)
        {
            return Repository.GetAll(filter);
        }
    }
}
