using System;
using System.Linq;
using Talks.C2DF.Interfaces.ExternalLibrary;

namespace Talks.C2DF.Interfaces
{
	public interface ILogger
	{
		void Info(string Message);
		void Debug(string Message);
		void Warn(string Message);
		void Error(string Message);
	}
}
