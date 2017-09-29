using System;
using System.Linq;

namespace Talks.C2DF.Interfaces.ExternalLibrary
{
	public class Logger: ILogger
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
			Console.WriteLine($"External library Logger ({logEntry.LogType} - {logId++}): {logEntry.Message}");
		}
	}
}
