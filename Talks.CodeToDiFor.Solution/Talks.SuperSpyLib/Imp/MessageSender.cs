using System;
using System.Collections.Generic;
using System.Linq;
using Talks.SuperSpyLib.Data;

namespace Talks.SuperSpyLib.Imp
{
    public class MessageSender : IMessageSender
    {
        ILogger logger;
        IDataLayer data;
        IShippingCalculator calc;

        public MessageSender(ILogger logger, IDataLayer data, IShippingCalculator calc)
        {
            this.logger = logger;
            this.data = data;
            this.calc = calc;
			Console.Write(" -> MessageSender Ctr");
		}

        public void Send(string Message)
        {
            logger.Log("Calculating Shipping Costs");
            var shippingCost = calc.CalculateCost(Message, 10.0m);

            logger.Log("Message was sent: " + Message);
            data.update("Store in db: " + Message);
        }
    }
}
