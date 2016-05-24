using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talks.SuperSpyLib
{
    public interface IEncrypter
    {
        string Encrypt(string Message);
    }
}
