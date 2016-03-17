using System;
using System.Collections.Generic;
using System.Linq;

namespace Talks.PCL.SuperSpyLib
{
    public interface IShippingCalculator
    {
        decimal CalculateCost(string Item, decimal WeightInLbs);
    }
}
