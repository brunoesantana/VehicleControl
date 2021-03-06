﻿using VehicleControl.CrossCutting.Filter;
using VehicleControl.Data.Interface.Base;
using VehicleControl.Domain;

namespace VehicleControl.Data.Interface
{
    public interface IMarcaRepository : IRepositoryBase<Marca, MarcaFilter>
    {
    }
}
