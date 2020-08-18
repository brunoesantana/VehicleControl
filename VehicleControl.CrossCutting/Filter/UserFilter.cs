using VehicleControl.CrossCutting.Filter.Base;

namespace VehicleControl.CrossCutting.Filter
{
    public class UserFilter : BaseFilter
    {
        public UserFilter(string term)
        {
            if (!string.IsNullOrWhiteSpace(term))
                Term = term.ToUpper();
        }
    }
}
