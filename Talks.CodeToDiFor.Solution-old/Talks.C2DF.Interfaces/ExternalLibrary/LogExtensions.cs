using System;
using System.Linq;

namespace Talks.C2DF.Interfaces.ExternalLibrary
{
	public static class LogExtensions
	{
		public static void Warn(this ILogger logger, string message)
		{
			if (logger.Enabled(LogType.Warn))
			{
				logger.Log(new LogEntry() { Message = message, LogType = LogType.Warn });
			}
		}

		public static void Debug(this ILogger logger, string message)
		{
			if (logger.Enabled(LogType.Debug))
			{
				logger.Log(new LogEntry() { Message = message, LogType = LogType.Debug });
			}
		}

		public static void Info(this ILogger logger, string message)
		{
			if (logger.Enabled(LogType.Info))
			{
				logger.Log(new LogEntry() { Message = message, LogType = LogType.Info });
			}
		}

		public static void Error(this ILogger logger, string message)
		{
			if (logger.Enabled(LogType.Error))
			{
				logger.Log(new LogEntry() { Message = message, LogType = LogType.Error });
			}
		}
	}
}
