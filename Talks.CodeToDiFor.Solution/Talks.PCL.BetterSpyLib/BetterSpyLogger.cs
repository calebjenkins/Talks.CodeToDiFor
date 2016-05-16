using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Talks.PCL.SuperSpyLib;

namespace Talks.PCL.BetterSpyLib
{
    public class BetterSpyLogger : ISpyLogger
    {
        private Stack<string> messages;
        private int count = 0;

        public BetterSpyLogger()
        {
            messages = new Stack<string>();
        }
        public IEnumerable<string> GetMessages()
        {
            return messages;
        }
        public Stack<string> GetMessagesStack()
        {
            return messages;
        }

        public void Log(string Message)
        {
            count++;
            messages.Push("Better Logger (" + count.ToString() + ") "
                + DateTime.Now.ToString() + " - " + Message);
        }
    }
}
