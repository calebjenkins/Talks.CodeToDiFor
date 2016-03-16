using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talks.SuperSpyLib;

namespace Talk.BetterSpyLib
{
    public class BetterSpyLogger : ISpyLogger
    {
        int count = 0;

        public IList<string> Log(IList<string> Current, string Message)
        {
            count++;
            Current.Add("BetterSpyLogger (" + count.ToString() + ")- " + DateTime.Now.ToString() + " - " + Message);

            return Current;
        }
    }
}
