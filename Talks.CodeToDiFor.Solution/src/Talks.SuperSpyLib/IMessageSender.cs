using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talks.SuperSpyLib
{
    public interface IMessageSender
    {
        IList<string> Send(IList<string> Current, string Message);
    }
}
