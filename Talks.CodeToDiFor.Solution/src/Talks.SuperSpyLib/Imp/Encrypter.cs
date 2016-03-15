using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talks.SuperSpyLib.Imp
{
    public class Encrypter : IEncrypter
    {
        public IList<string> Encrypt(IList<string> Current, string Message)
        {
            Current.Add("Encrypter: " + Message);
            return Current;
        }
    }
}
