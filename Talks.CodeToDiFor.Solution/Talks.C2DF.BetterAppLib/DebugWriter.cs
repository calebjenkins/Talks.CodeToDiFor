using System;
using System.Linq;

namespace Talks.C2DF.BetterApp.Lib
{
	public class DebugWriter: IWriter
	{
		public void Write(string text = "")
		{
			System.Diagnostics.Debug.Write(text);
		}

		public void WriteLine(string text = "")
		{
			System.Diagnostics.Debug.WriteLine(text);
		}
	}
}
