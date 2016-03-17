using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talks.PCL.SuperSpyLib.Imp
{
    public class Encrypter : IEncrypter
    {
        public string Encrypt(string Message)
        {
            return "Encrypted : " + Message;
        }
    }
}
