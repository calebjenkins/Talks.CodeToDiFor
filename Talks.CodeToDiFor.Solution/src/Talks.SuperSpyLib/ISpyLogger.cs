using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talks.SuperSpyLib
{
    public interface ISpyLogger
    {
        IList<string> Log(IList<string> Current, string Message);
    }
}
