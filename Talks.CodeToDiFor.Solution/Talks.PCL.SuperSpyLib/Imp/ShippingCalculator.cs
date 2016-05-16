using System;
using System.Collections.Generic;
using System.Linq;
using Talks.PCL.SuperSpyLib.Rules.Shipping;

namespace Talks.PCL.SuperSpyLib.Imp
{
    public class ShippingCalculator : IShippingCalculator
    {
        ISpyLogger logger;
        IList<IShippingRule> rules;

        public ShippingCalculator(ISpyLogger logger, IList<IShippingRule> rules)
        {
            this.logger = logger;
            this.rules = rules;
        }


        public decimal CalculateCost(string Item, decimal BaseCost)
        {
            logger.Log("Calculating Shipping cost for " + Item);
            var weight = Item.Length;

            // Complex Shipping Rules go here.. 
            var cost = (weight > 10) ? Convert.ToDecimal(5.0) : Convert.ToDecimal(2.0);
            logger.Log("Cost to ship " + Item + " is " + cost.ToString());

            // ..Or...
            foreach (var rule in rules)
            {
                if(rule.AppliesTo(Item))
                {
                    cost = rule.ApplyShippingRule(Item, cost);
                    logger.Log("Shipping Cost Rule Applied: " + rule.RuleName());
                }
            }

            return cost;
        }
    }
}
