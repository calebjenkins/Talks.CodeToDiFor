using System;
using System.Collections.Generic;
using System.Linq;

namespace Talks.PCL.SuperSpyLib.Rules.Shipping
{
    public class EconomyShippingDiscountRule : IShippingRule
    {
        public bool AppliesTo(string Message)
        {
            return Message.Count() < 5;
        }

        public decimal ApplyShippingRule(string Message, decimal CurrentShippingPrice)
        {
            if (AppliesTo(Message))
            {
                return CurrentShippingPrice * .9m;
            }
            else
            {
                return CurrentShippingPrice;
            }
        }

        public string RuleName()
        {
            return "EconomyShippingDiscountRule";
        }
    }
}
