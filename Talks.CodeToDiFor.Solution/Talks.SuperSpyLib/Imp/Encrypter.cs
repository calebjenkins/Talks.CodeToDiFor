using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.SuperSpyLib.Rules;

namespace Talks.SuperSpyLib.Imp
{
    public class Encrypter : IEncrypter
    {
        ISpyLogger logger;
        public Encrypter(ISpyLogger logger)
        {
            this.logger = logger;
        }

        public string Encrypt(string Message)
        {
            logger.Log("Encrypted: Message");

            return "Encrypted : " + Message;
        }
    }
}
