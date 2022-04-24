using System;

namespace Talks.C2DF.BetterAppLib.Logging
{
	public static class LoggerExtensions
	{
		public static void Write(this IAppLogger logger, string message)
		{
			logger.Debug(message);
		}
		public static void WriteLine(this IAppLogger logger, string message)
		{
			logger.Debug(message);
		}
	}
}
