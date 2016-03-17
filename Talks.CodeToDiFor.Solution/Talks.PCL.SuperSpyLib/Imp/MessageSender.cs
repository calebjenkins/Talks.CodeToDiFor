using System;
using System.Collections.Generic;
using System.Linq;

namespace Talks.PCL.SuperSpyLib.Imp
{
    public class MessageSender : IMessageSender
    {
        ISpyLogger logger;


        public MessageSender(ISpyLogger logger)
        {
            this.logger = logger;
        }

        public void Send(string Message)
        {
            logger.Log("Message was sent: " + Message);
        }
    }
}
