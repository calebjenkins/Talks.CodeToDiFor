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
        ILogger logger;
        public Encrypter(ILogger logger)
        {
            this.logger = logger;

			Console.Write(" -> Encrypter Ctr");
		}

        public string Encrypt(string Message)
        {
            logger.Log("Encrypted: Message");

            return "Encrypted : " + Message;
        }
    }
}
