using System;
using System.Collections.Generic;
using System.Linq;

namespace Talks.SuperSpyLib.Rules.Shipping
{
    public class RushOrderShippingRule : IShippingRule
    {
        public bool AppliesTo(string Message)
        {
            return Message.Contains("!");
        }

        public decimal ApplyShippingRule(string Message, decimal CurrentShippingPrice)
        {
            if (AppliesTo(Message))
            {
                return CurrentShippingPrice * 1.25m;
            }
            else
            {
                return CurrentShippingPrice;
            }
        }

        public string RuleName()
        {
            return "RushOrderShippingRule";
        }
    }
}
