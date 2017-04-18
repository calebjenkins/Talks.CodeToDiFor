using System;
using System.Collections.Generic;
using System.Linq;

namespace Talks.SuperSpyLib
{
    public interface ILogger
    {
        void Log(string Message);
        IEnumerable<string> GetMessages();
        Stack<string> GetMessagesStack();
    }
}
