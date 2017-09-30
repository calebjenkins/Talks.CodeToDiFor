using System;
using System.Linq;

namespace Talks.C2DF.BetterApp.Lib.Console
{
	public interface IWriter
	{
		void Write(string text);
		void Write();

		void WriteLine(string text);
		void WriteLine();

	}
}
