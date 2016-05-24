using System;
using System.Collections.Generic;
using System.Linq;
using Talks.SuperSpyLib.Data;

namespace Talks.SuperSpyLib.Imp
{
    public class SpyDataLayer : ISpyDataLayer
    {

        ISpyLogger logger;
        IEncrypter encrypt;

        public SpyDataLayer(ISpyLogger logger, IEncrypter encrypt)
        {
            this.logger = logger;
            this.encrypt = encrypt;
        }

        public void update(string Message)
        {
            logger.Log("Storing in DB: " + Message);
            string xMsg = encrypt.Encrypt(Message);
            logger.Log("Encrypted: " + xMsg);

        }
    }
}
