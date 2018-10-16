using System;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Models;
using Talks.C2DF.NotSoSuperLib.Lib;

namespace Talks.C2DF.NotSoSuperLib
{
	public class NotSoGreatSendingMicroApp : IMessageSendingMicroApp
	{
		public SendResponse Send(string message)
		{
			CostCalculator calc = new CostCalculator();
			Sender sender = new Sender();

			var price = calc.CalculatePrice(message);
			sender.Send(message);

			return new SendResponse()
			{
				Message = message,
				Price = price,
				ResultMessage = "success"
			};
		}
	}
}
