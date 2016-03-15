using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talks.SuperSpyLib.Imp
{
    public class SpyLogger : ISpyLogger
    {
        public IList<string> Log(IList<string> Current, string Message)
        {
            Current.Add("SpyLogger: " + Message);
            return Current;
        }
    }
}
