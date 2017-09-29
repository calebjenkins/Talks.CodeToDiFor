using System;
using System.Linq;

namespace Talks.C2DF.BetterApp.Lib.Console
{
	public interface IWriter
	{
		void Write(string text = "");
		void WriteLine(string text = "");
	}
}
