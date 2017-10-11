using Talks.C2DF.BetterApp.Lib.Console;
using Talks.C2DF.BetterApp.Lib.Logging;
using Talks.C2DF.Interfaces.ExternalLibrary;

namespace Talks.C2DF.BetterApp.Lib.v2Features
{
	public class MyLogger : IAppLogger
	{
		private int logId;
		readonly IWriter _writer;
		public MyLogger(IWriter writer)
		{
			_writer = writer;
			logId = 0;
		}

		private void log(LogType type, string message)
		{
			_writer.WriteLine($"Ext Logger -{type}- ({logId++}): {message}");
		}

		public void Info(string Message)
		{
			log(LogType.Info, Message);
		}

		public void Debug(string Message)
		{
			log(LogType.Debug, Message);
		}

		public void Warn(string Message)
		{
			log(LogType.Warn, Message);
		}

		public void Error(string Message)
		{
			log(LogType.Error, Message);
		}
	}
}
