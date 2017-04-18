using System;
using System.Collections.Generic;
using System.Linq;
using Talks.SuperSpyLib.Data;

namespace Talks.SuperSpyLib.Imp
{
    public class DataLayer : IDataLayer
    {

        ILogger logger;
        IEncrypter encrypt;

        public DataLayer(ILogger logger, IEncrypter encrypt)
        {
            this.logger = logger;
            this.encrypt = encrypt;
			Console.Write(" -> SpyDataLayer Ctr");
		}

        public void update(string Message)
        {
            logger.Log("Storing in DB: " + Message);
            string xMsg = encrypt.Encrypt(Message);
            logger.Log("Encrypted: " + xMsg);

        }
    }
}
