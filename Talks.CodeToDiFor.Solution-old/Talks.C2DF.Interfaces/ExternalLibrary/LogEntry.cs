using System;
using System.Linq;

namespace Talks.C2DF.Interfaces.ExternalLibrary
{
	public class LogEntry
	{
		public LogType LogType { get; set; }
		public string Message { get; set; }
	}
}
