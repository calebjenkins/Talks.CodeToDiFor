using System;
using System.Collections.Generic;
using System.Linq;

namespace Talks.PCL.SuperSpyLib.Imp
{
    public class ShippingCalculator : IShippingCalculator
    {
        ISpyLogger logger;

        public ShippingCalculator(ISpyLogger logger)
        {
            this.logger = logger;
        }


        public decimal CalculateCost(string Item, decimal WeightInLbs)
        {
            logger.Log("Calculating Shipping cost for " + Item);

            var cost = (WeightInLbs > 10) ? Convert.ToDecimal(5.0) : Convert.ToDecimal(2.0);
            logger.Log("Cost to ship " + Item + " is " + cost.ToString());

            return cost;
        }
    }
}
