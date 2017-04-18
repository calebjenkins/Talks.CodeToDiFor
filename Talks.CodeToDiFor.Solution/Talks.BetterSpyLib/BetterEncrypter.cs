using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Talks.SuperSpyLib;

namespace Talks.BetterSpyLib
{
    public class BetterEncrypter : IEncrypter
    {

        ILogger logger;

        public BetterEncrypter(ILogger logger)
        {
            this.logger = logger;
			Console.Write(" -> BetterEncryption Ctr");
		}

        public string Encrypt(string Message)
        {
            logger.Log("Better Encrypting: " + Message);
            var msg = "Encrypted: " + Message;
            var x = msg.Reverse();

            var sb = new StringBuilder();
            foreach (var c in x)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
