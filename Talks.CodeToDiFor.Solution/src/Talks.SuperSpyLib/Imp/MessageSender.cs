using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talks.SuperSpyLib.Data;

namespace Talks.SuperSpyLib.Imp
{
    public class MessageSender : IMessageSender
    {
        IEncrypter encrypter;
        IDataLayer data;
        ISpyLogger logger;

        
        public MessageSender(IEncrypter EncryptionYo, ISpyLogger SuperSpyLogger, IDataLayer BigDATA)
        {
            encrypter = EncryptionYo;
            data = BigDATA;
            logger = SuperSpyLogger;
        }
        public IList<string> Send(IList<string> Current, string Message)
        {
            Current.Add("MessageSender: " + Message);
            Current = encrypter.Encrypt(Current, "Secret Message!!");
           Current = data.Update(Current, "Storing Data!");

            Current = logger.Log(Current, "The Secret Message has been sent!");

            return Current;
        }
    }
}
