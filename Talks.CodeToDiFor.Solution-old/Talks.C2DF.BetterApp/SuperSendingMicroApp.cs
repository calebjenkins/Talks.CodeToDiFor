using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.C2DF.BetterApp.Lib.Logging;
using Talks.C2DF.Interfaces;
using Talks.C2DF.Interfaces.Models;

namespace Talks.C2DF.BetterApp
{
	public class SuperSendingMicroApp: ISendingMicroApp
	{
		readonly ICostCalculator _cost;
		readonly IMessageSender _sender;
		readonly IAppLogger _logger;

		public SuperSendingMicroApp(ICostCalculator cost, IMessageSender sender, IAppLogger logger)
		{
			_cost = cost ?? throw new ArgumentNullException(nameof(cost), $"{nameof(cost)} is null.");
			_sender = sender ?? throw new ArgumentNullException(nameof(sender), $"{nameof(sender)} is null.");
			_logger = logger ?? throw new ArgumentNullException(nameof(logger), $"{nameof(logger)} is null.");
		}

		public SendResponse Send(string message)
		{
			try
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
			catch (Exception ex)
			{
				_logger.Error($"There was an error: {ex.Message}");

				return new SendResponse()
				{
					Message = string.Empty,
					Price = 0,
					ResultMessage = "Fail"
				};
			}
		}
	}
}
