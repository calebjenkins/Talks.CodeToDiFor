using System;
using System.Collections.Generic;
using System.Linq;

namespace Talks.SuperSpyLib.Rules.Shipping
{
    public class GodSaveTheQueenShippingRule : IShippingRule
    {
        public bool AppliesTo(string Message)
        {
            return Message.ToUpper().Contains("GOD SAVE THE QUEEN");
        }

        public decimal ApplyShippingRule(string Message, decimal CurrentShippingPrice)
        {
            if (AppliesTo(Message))
            {
                return CurrentShippingPrice * 0m;
            }
            else
            {
                return CurrentShippingPrice;
            }
        }

        public string RuleName()
        {
            return "GodSaveTheQueenShippingRule";
        }
    }
}
