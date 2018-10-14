using System;
using System.Linq;

namespace Talks.C2DF.Interfaces
{
	public interface IMessageSender
	{
		void Send(string message);
	}
}
