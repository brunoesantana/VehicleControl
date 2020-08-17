using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace VehicleControl.CrossCutting.Helper
{
    public static class MapperHelper
    {
        public static IEnumerable<TDestiny> CopyList<TOrigin, TDestiny>(IEnumerable<TOrigin> src)
        {
            var ret = new List<TDestiny>();
            if (src == null)
            {
                return ret;
            }

            ret.AddRange(src.Select(origin => (TDestiny)Mapper.Map(origin, typeof(TOrigin), typeof(TDestiny))));
            return ret;
        }

        public static TDestiny Map<TSource, TDestiny>(TSource origin)
        {
            return Mapper.Map<TDestiny>(origin);
        }
    }
}
