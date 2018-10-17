//using Polly;
using System;
using System.Linq;
using Talks.C2DF.BetterAppLib.Logging;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterAppLib.v2Features
{
	public class RetrySender : IMessageSender
	{
		IAppLogger _logger;
		IMessageSender _sender;

		public RetrySender(IAppLogger logger, IMessageSender sender)
		{
			_logger = logger;
			_sender = sender;
		}

		public void Send(string message)
		{
			// Non-Polly Hack - Polly was causing Lamar to choak
			const int retry = 3;
			try
			{
				for (int retryCount = 0; retryCount < retry; retryCount++)
				{
					_logger.Info($"Attempt {retryCount} to send message");
					try
					{
						_sender.Send(message);
						break; // success
					}
					catch
					{
						continue; // retry
					}
				}
			}
			catch (Exception ex)
			{
				_logger.Error($"Error trying to send message: {ex.Message}");
			}
		}
	}
}
