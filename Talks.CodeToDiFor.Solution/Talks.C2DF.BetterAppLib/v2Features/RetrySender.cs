using System;
using Polly;
using Talks.C2DF.BetterApp.Lib.Logging;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterApp.Lib.v2Features
{
	public class RetrySender: ISender
	{
		IAppLogger _logger;
		ISender _sender;

		public RetrySender(IAppLogger logger, ISender sender)
		{
			_logger = logger;
			_sender = sender;
		}

		public void Send(string message)
		{
			var retryPolicy =
						Policy.Handle<Exception>()
						.WaitAndRetry(3, (retryCount) =>
						{
							_logger.Info($"Attempt {retryCount} to send message");
							return TimeSpan.FromSeconds(0);
						},
							(exception, timespan) =>
							{
								_logger.Error($"Error trying to send message: {exception.Message}");
							});

			retryPolicy.Execute(() => _sender.Send(message));
		}
	}
}
