using System;
using System.Collections.Generic;
using System.Linq;
using Talks.PCL.SuperSpyLib.Data;

namespace Talks.PCL.SuperSpyLib.Imp
{
    public class MessageSender : IMessageSender
    {
        ISpyLogger logger;
        ISpyDataLayer data;

        public MessageSender()
        {
            logger = new SpyLogger();
            IEncrypter enc = new Encrypter(logger);
            data = new SpyDataLayer(logger, enc);
        }

        public MessageSender(ISpyLogger logger)
        {
            this.logger = logger;
            IEncrypter enc = new Encrypter(logger);
            data = new SpyDataLayer(logger, enc);
        }

        public MessageSender(ISpyLogger logger, ISpyDataLayer Data)
        {
            this.logger = logger;
            data = Data;
        }

        public void Send(string Message)
        {
            logger.Log("Message was sent: " + Message);
            data.update("Store in db: " + Message);
        }
    }
}
