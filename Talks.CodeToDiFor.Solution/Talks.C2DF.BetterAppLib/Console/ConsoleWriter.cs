using System;
using System.Linq;

namespace Talks.C2DF.BetterApp.Lib.Console
{
	public class ConsoleWriter: IConsole 
	{
		public ConsoleColor ForegroundColor { get => System.Console.ForegroundColor; set => System.Console.ForegroundColor = value; }

		public void Clear()
		{
			System.Console.Clear();
		}

		public ConsoleKeyInfo ReadKey()
		{
			return System.Console.ReadKey();
		}

		public string ReadLine()
		{
			return System.Console.ReadLine();
		}

		// IWriter
		public void Write()
		{
			Write("");
		}
		public void Write(string text)
		{
			System.Console.Write(text);
		}
		public void WriteLine()
		{
			WriteLine("");
		}
		public void WriteLine(string text)
		{
			System.Console.WriteLine(text);
		}
	}
}
