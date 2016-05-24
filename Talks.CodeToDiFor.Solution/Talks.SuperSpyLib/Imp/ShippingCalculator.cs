using System;
using System.Collections.Generic;
using System.Linq;
using Talks.SuperSpyLib.Rules.Shipping;

namespace Talks.SuperSpyLib.Imp
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

            // Complex Shipping Rules go here.. 
            var weight = Item.Length;
            var cost = (weight > 10) ? Convert.ToDecimal(5.0) : Convert.ToDecimal(2.0);

            // ..Or...

            cost = BaseCost;
            foreach (var rule in rules)
            {
                if(rule.AppliesTo(Item))
                {
                    cost = rule.ApplyShippingRule(Item, cost);
                    logger.Log("Shipping Cost Rule Applied: " + rule.RuleName());
                }
            }

            logger.Log("Cost to ship " + Item + " is " + cost.ToString());
            return cost;
        }
    }
}
