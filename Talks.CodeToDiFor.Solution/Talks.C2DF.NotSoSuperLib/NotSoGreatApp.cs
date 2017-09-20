using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Interfaces.Models;
using Talks.C2DF.NotSoSuperLib.Lib;

namespace Talks.C2DF.NotSoSuperLib
{
	public class NotSoGreatApp : ISuperApplication
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
