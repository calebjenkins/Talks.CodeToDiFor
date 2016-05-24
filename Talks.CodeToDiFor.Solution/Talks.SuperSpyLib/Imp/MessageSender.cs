using System;
using System.Collections.Generic;
using System.Linq;
using Talks.SuperSpyLib.Data;

namespace Talks.SuperSpyLib.Imp
{
    public class MessageSender : IMessageSender
    {
        ISpyLogger logger;
        ISpyDataLayer data;
        //IShippingCalculator calc;

        //public MessageSender()
        //{
        //    logger = new SpyLogger();
        //    IEncrypter enc = new Encrypter(logger);
        //    data = new SpyDataLayer(logger, enc);
        //}

        //public MessageSender(ISpyLogger logger)
        //{
        //    this.logger = logger;
        //    IEncrypter enc = new Encrypter(logger);
        //    data = new SpyDataLayer(logger, enc);
        //}

        public MessageSender(ISpyLogger logger, ISpyDataLayer Data)
        {
            this.logger = logger;
            data = Data;
        }

        //public MessageSender(ISpyLogger logger, ISpyDataLayer data, IShippingCalculator calc)
        //{
        //    this.logger = logger;
        //    this.data = data;
        //    this.calc = calc;
        //}

        public void Send(string Message)
        {
            //logger.Log("Calculating Shipping Costs");
            //var shippingCost = calc.CalculateCost(Message, 10.0m);

            logger.Log("Message was sent: " + Message);
            data.update("Store in db: " + Message);
        }
    }
}
