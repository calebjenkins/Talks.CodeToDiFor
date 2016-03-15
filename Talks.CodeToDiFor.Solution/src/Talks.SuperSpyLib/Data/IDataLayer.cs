using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talks.SuperSpyLib.Data
{
    interface IDataLayer
    {
        IList<string> Update(IList<string> Context, string Data);
    }
}
