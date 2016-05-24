using System;
using System.Collections.Generic;
using System.Linq;

namespace Talks.SuperSpyLib
{
    public interface IMessageSender
    {
        void Send(string Message);
    }
}
