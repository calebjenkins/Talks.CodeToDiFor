using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talks.SuperSpyLib.Data;

namespace Talks.SuperSpyLib.Imp
{
    public class DataLayer : IDataLayer
    {
        public IList<string> Update(IList<string> Context, string Data)
        {
            Context.Add("DataLayer: " + Data);
            return Context;
        }
    }
}
