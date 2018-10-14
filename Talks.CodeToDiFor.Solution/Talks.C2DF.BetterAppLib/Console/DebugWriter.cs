using System;

namespace Talks.C2DF.BetterAppLib.Console
{
	public class DebugWriter : IWriter
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
