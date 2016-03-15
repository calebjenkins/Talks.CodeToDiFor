using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talks.SuperSpyLib.Data;

namespace Talks.SuperSpyLib.Imp
{
    public class DataLayer : IDataLayer
    {
        IEncrypter crypto;
        ISpyLogger logger;

        public DataLayer(IEncrypter Encrypter, ISpyLogger LogIt)
        {
            crypto = Encrypter;
            logger = LogIt;
        }

        public IList<string> Update(IList<string> Context, string Data)
        {
            Context = crypto.Encrypt(Context, "Encrypt before putting in DB!");
            Context.Add("DataLayer: " + Data);
            Context = logger.Log(Context, "Stored in DB");

            return Context;
        }
    }
}
