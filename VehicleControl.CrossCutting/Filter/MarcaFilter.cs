using VehicleControl.CrossCutting.Filter.Base;

namespace VehicleControl.CrossCutting.Filter
{
    public class MarcaFilter : BaseFilter
    {
        public MarcaFilter(string term)
        {
            if (!string.IsNullOrWhiteSpace(term))
                Term = term.ToUpper();
        }
    }
}
