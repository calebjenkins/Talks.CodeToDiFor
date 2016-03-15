using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talks.SuperSpyLib;

namespace Talk.BetterSpyLib
{
    public class BetterEncryption : IEncrypter
    {
        public IList<string> Encrypt(IList<string> Current, string Message)
        {
            Current.Add("Better Encrypter: " + Message.Reverse());
            return Current;
        }


    }
}
