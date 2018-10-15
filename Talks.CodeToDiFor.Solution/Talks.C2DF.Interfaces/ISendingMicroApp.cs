using System;
using Talks.C2DF.Models;

namespace Talks.C2DF.Interfaces
{
	public interface ISendingMicroApp
	{
		SendResponse Send(string message);
	}
}
