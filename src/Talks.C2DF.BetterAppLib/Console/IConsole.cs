using System;

namespace Talks.C2DF.BetterAppLib.Console;

public interface IConsole : IWriter
{
	ConsoleColor ForegroundColor { get; set; }
	string ReadLine();
	ConsoleKeyInfo ReadKey();
	void Clear();
}
