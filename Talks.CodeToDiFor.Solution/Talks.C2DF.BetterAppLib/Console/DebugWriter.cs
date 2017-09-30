using System;
using System.Linq;

namespace Talks.C2DF.BetterApp.Lib.Console
{
	public class DebugWriter: IWriter
	{
		public void Write()
		{
			Write("");
		}
		public void Write(string text)
		{
			System.Diagnostics.Debug.Write(text);
		}
		public void WriteLine()
		{
			WriteLine("");
		}
		public void WriteLine(string text)
		{
			System.Diagnostics.Debug.WriteLine(text);
		}
	}
}
