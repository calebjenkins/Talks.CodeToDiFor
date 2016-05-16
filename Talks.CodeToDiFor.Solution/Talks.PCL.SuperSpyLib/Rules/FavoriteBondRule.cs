using System;
using System.Collections.Generic;
using System.Linq;

namespace Talks.PCL.SuperSpyLib.Rules
{
    public class FavoriteBondRule : IRule
    {
        public string RuleName()
        {
            return "Favorite: Pierce Bronson";
        }
    }
}
