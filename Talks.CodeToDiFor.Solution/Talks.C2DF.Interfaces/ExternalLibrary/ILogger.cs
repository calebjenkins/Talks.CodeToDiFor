using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talks.C2DF.Interfaces.ExternalLibrary
{
	public interface ILogger
	{
		void Log(LogEntry logEntry);
		bool Enabled(LogType type);
	}
}
