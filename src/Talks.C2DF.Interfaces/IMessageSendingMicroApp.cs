using System;
using Talks.C2DF.Models;

namespace Talks.C2DF.Interfaces
{
	public interface IMessageSendingMicroApp
	{
		SendResponse Send(string message);
	}
}
