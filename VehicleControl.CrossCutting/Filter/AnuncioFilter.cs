using System;
using VehicleControl.CrossCutting.Filter.Base;

namespace VehicleControl.CrossCutting.Filter
{
    public class AnuncioFilter: BaseFilter
    {
        public AnuncioFilter(string term, DateTime? initialDate, DateTime? finalDate)
        {
            if (!string.IsNullOrWhiteSpace(term))
                Term = term.ToUpper();

            InitialDate = initialDate;
            FinalDate = finalDate;
        }

        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
    }
}
