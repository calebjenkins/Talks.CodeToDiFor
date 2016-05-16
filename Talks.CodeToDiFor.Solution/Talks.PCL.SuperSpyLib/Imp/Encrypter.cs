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
        IList<IRule> rules;
        ISpyLogger logger;
        public Encrypter(ISpyLogger logger)
        {
            this.logger = logger;
        }

        public Encrypter(ISpyLogger logger, IList<IRule> rules)
        {
            this.logger = logger;
            this.rules = rules;
        }
        public string Encrypt(string Message)
        {
            logger.Log("Encrypted: Message");

            if(rules != null)
            {
                foreach (var r in rules)
                {
                    logger.Log("Bond Rule: " + r.RuleName());
                }
            }

            return "Encrypted : " + Message;
        }
    }
}
