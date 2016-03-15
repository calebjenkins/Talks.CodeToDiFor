using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talks.SuperSpyLib.Imp
{
    public class MessageSender : IMessageSender
    {
        public IList<string> Send(IList<string> Current, string Message)
        {
            Current.Add("MessageSender: " + Message);
            return Current;
        }
    }
}
