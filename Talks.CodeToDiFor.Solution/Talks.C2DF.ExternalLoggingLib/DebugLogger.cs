using System;
using System.Collections.Generic;

namespace Talks.C2DF.ExternalLoggingLib
{
	public class DebugLogger : ILogger
	{
		int logId = 0;
		private IList<LogEntry> _logs = new List<LogEntry>();
		
		// Used for Hard coded singleton
		private static ILogger _instance = null;
		public static ILogger Instance()
		{
			if (_instance == null)
			{
				_instance = new Logger();
			}

			return _instance;
		}

		public bool Enabled(LogType type)
		{
			return true;
		}

		public void Log(LogEntry logEntry)
		{
			System.Diagnostics.Debug.WriteLine($"Ext Logger -{logEntry.LogType}- ({logId++}): {logEntry.Message}");
			_logs.Add(logEntry);
		}

		public IList<LogEntry> GetEntries()
		{
			return _logs;
		}
	}
}
