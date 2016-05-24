using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talks.SuperSpyLib.Rules.Shipping
{
    public interface IShippingRule : IRule
    {
        bool AppliesTo(string Message);
        decimal ApplyShippingRule(string Message, decimal CurrentShippingPrice);
    }
}
