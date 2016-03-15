using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talks.SuperSpyLib
{
    public interface IShippingCalculator
    {
        IList<string> Calculate(IList<string> Current, string Value);
    }
}
