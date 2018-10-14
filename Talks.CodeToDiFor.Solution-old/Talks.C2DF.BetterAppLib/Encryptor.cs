using System;
using Talks.C2DF.BetterApp.Lib.Logging;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.BetterApp.Lib
{
	public class Encryptor: IEncryptHelper
	{
		readonly IAppLogger _logger;

		public Encryptor(IAppLogger logger)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger), $"{nameof(logger)} is null.");
		}

		public string Decrypt(string message)
		{
			_logger.WriteLine("Decrypting Message"); // using "local" extension methods
			return message.Replace("xXX_", "").Replace("_XXx", "");

		}

		public string Encrypt(string message)
		{
			_logger.Write($"Encrypting Message: {message} : ");

			var encMsg = $"xXX_{message}_XXx";
			_logger.WriteLine($" Encrypted: {encMsg}");

			return encMsg;
		}
	}
}
