namespace Talks.C2DF.Interfaces;

public interface IEncryptHelper
{
	string Encrypt(string message);
	string Decrypt(string message);
}
