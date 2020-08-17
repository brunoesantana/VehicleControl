using VehicleControl.CrossCutting.Filter.Base;

namespace VehicleControl.CrossCutting.Filter
{
    public class ModeloFilter : BaseFilter
    {
        public ModeloFilter(string term)
        {
            if (!string.IsNullOrWhiteSpace(term))
                Term = term.ToUpper();
        }
    }
}
