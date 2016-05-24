using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Talks.SuperSpyLib;

namespace Talks.BetterSpyLib
{
    public class BetterEncrypter : IEncrypter
    {

        ISpyLogger logger;

        public BetterEncrypter(ISpyLogger logger)
        {
            this.logger = logger;
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
