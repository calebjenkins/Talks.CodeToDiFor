using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.PCL.SuperSpyLib.Rules;

namespace Talks.PCL.SuperSpyLib.Imp
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
