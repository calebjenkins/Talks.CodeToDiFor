using System;
using System.Collections.Generic;
using System.Text;

namespace Talks.C2DF.BetterAppLib.Console
{
	public interface IConsole : IWriter
	{
		ConsoleColor ForegroundColor { get; set; }
		string ReadLine();
		ConsoleKeyInfo ReadKey();
		void Clear();
	}
}
