using System;
using System.Linq;
using Talks.C2DF.Interfaces;

namespace Talks.C2DF.NotSoSuperLib.Lib
{
	public class Encryptor: IEncryptHelper
	{
		public string Decrypt(string message)
		{
			Console.WriteLine("Decrypting Message");
			return message.Replace("xXX_", "").Replace("_XXx", "");

		}

		public string Encrypt(string message)
		{
			Console.WriteLine("Encrypting Message");
			return $"xXX_{message}_XXx";
		}
	}
}
