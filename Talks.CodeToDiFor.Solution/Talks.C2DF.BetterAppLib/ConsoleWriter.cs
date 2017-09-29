using System;
using System.Linq;

namespace Talks.C2DF.BetterApp
{
	public class ConsoleWriter: IWriter
	{
		public void Write(string text = "")
		{
			Console.Write(text);
		}

		public void WriteLine(string text = "")
		{
			Console.WriteLine(text);
		}
	}
}
