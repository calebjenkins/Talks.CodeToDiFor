using System;
using System.Collections.Generic;
using System.Linq;

namespace Talks.PCL.SuperSpyLib.Rules.Shipping
{
    public class ExtraLargeShippingRule : IShippingRule
    {
        public bool AppliesTo(string Message)
        {
            return Message.Count() > 10;
        }

        public decimal ApplyShippingRule(string Message, decimal CurrentShippingPrice)
        {
            if (AppliesTo(Message))
            {
                return CurrentShippingPrice * 3m;
            }
            else
            {
                return CurrentShippingPrice;
            }
        }

        public string RuleName()
        {
            return "ExtraLargeShippingRule";
        }
    }
}
