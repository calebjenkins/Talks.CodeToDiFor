using System;

namespace Talks.C2DF.BetterAppLib.Console
{
	public interface IWriter
	{
		void Write(string text);
		void Write();

		void WriteLine(string text);
		void WriteLine();

	}
}
