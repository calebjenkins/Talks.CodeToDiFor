using System;

namespace Talks.C2DF.BetterApp.Lib.Logging
{
	public interface ILogger
	{
		void Info(string Message);
		void Debug(string Message);
		void Warn(string Message);
		void Error(string Message);
	}
}
