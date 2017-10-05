using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.C2DF.Interfaces.Models;

namespace Talks.C2DF.Interfaces
{
	public interface ISendingMicroApp
	{
		SendResponse Send(string message);
	}
}
