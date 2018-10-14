using System;

namespace Talks.C2DF.ExternalLoggingLib
{
	public class DebugLogger : ILogger
	{
		int logId = 0;

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
		}
	}
}
