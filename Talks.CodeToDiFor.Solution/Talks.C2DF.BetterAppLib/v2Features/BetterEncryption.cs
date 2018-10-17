//using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talks.C2DF.BetterAppLib.Console;
using Talks.C2DF.BetterAppLib.Logging;
using Talks.C2DF.ExternalLoggingLib;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterAppLib.v2Features
{
	public class BetterEncryptor : IEncryptHelper
	{

		readonly IAppLogger _logger;
		public BetterEncryptor(IAppLogger logger)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger), $"{nameof(logger)} is null.");
		}

		public string Decrypt(string message)
		{

			_logger.Debug($"BetterEncryptor - Decrypting Message: {message} : ");
			return Reverse(message);
		}

		public string Encrypt(string message)
		{
			_logger.Debug($"BetterEncryptor - Encrypting Message: {message} : ");
			return Reverse(message);
		}

		private string Reverse(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}
	}
}
