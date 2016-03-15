using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talks.SuperSpyLib.Imp
{
    public class ShippingCalculator : IShippingCalculator
    {
        public IList<string> Calculate(IList<string> Current, string Value)
        {
            Current.Add("ShippingCalculator: " + Value);
            return Current;
        }
    }
}
