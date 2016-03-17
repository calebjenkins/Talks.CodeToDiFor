using System;
using System.Collections.Generic;
using System.Linq;

namespace Talks.PCL.SuperSpyLib
{
    public interface IMessageSender
    {
        void Send(string Message);
    }
}
