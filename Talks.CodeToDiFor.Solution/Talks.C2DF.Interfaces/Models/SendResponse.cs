using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talks.C2DF.Interfaces.Models
{
	public class SendResponse
	{
		public int Price { get; set; }
		public string Message { get; set; }
		public string ResultMessage { get; set; }
	}
}
