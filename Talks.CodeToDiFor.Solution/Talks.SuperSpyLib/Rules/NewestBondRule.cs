using System;
using System.Collections.Generic;
using System.Linq;

namespace Talks.SuperSpyLib.Rules
{
    public class NewestBondRule : IRule
    {
        public string RuleName()
        {
            return "Newest: Daniel Craig";
        }
    }
}
