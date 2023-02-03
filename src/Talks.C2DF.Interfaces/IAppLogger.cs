namespace Talks.C2DF.Interfaces;

public interface IAppLogger // used to wrap Extension Methods from external Library
{
	void Info(string Message);
	void Debug(string Message);
	void Warn(string Message);
	void Error(string Message);
}
