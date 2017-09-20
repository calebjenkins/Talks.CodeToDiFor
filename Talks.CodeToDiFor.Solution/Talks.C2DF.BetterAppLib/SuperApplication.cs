using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Interfaces.Models;

namespace Talks.C2DF.BetterApp
{
	public class SuperApplication: ISuperApplication
	{
		ICostCalculator _cost;
		ISender _sender;
		public SuperApplication(ICostCalculator cost, ISender sender)
		{
			_cost = cost;
			_sender = sender;
		}

		public SendResponse Send(string message)
		{
			int price = _cost.CalculatePrice(message);
			_sender.Send(message);

			return new SendResponse()
			{
				Message = message,
				Price = price,
				ResultMessage = "Success"
			};
		}
	}
}
