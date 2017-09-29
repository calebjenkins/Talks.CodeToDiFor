using System;
using System.Linq;

namespace Talks.C2DF.BetterApp.Lib.Console
{
	public interface IConsole: IWriter
	{
		ConsoleColor ForegroundColor { get; set; }
		string ReadLine();
		ConsoleKeyInfo ReadKey();
		void Clear();
	}
}
