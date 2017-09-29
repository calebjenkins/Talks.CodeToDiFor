using System;
using System.Linq;

namespace Talks.C2DF.BetterApp.Lib
{
	public interface IWriter
	{
		void Write(string text = "");
		void WriteLine(string text = "");
	}
}
