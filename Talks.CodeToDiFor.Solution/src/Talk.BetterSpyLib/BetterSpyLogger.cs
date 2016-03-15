using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talks.SuperSpyLib;

namespace Talk.BetterSpyLib
{
    public class BetterSpyLogger : ISpyLogger
    {
        public IList<string> Log(IList<string> Current, string Message)
        {
            Current.Add("BetterSpyLogger - " + DateTime.Now.ToString() + " - " + Message);
            return Current;
        }
    }
}
