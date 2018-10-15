using System;
using System.Collections.Generic;

namespace Talks.C2DF.ExternalLoggingLib
{
	public interface ILogger
	{
		void Log(LogEntry logEntry);
		bool Enabled(LogType type);
		IList<LogEntry> GetEntries();
	}
}
