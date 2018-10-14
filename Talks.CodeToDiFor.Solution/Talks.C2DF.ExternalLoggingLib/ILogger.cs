using System;

namespace Talks.C2DF.ExternalLoggingLib
{
	public interface ILogger
	{
		void Log(LogEntry logEntry);
		bool Enabled(LogType type);
	}
}
