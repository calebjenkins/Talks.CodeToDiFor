using System;
using System.Linq;

namespace Talks.C2DF.Interfaces.Models
{
	public class MessageForProcessing
	{
		public int Weight { get; set; }
		public int CurrentPrice { get; set; }
		public string Text { get; set; }
	}
}
