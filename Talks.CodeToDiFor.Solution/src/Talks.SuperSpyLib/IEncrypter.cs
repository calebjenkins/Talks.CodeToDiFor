using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Talks.SuperSpyLib
{
    public interface IEncrypter
    {
        IList<string> Encrypt(IList<string> Current, string Message);
    }
}
