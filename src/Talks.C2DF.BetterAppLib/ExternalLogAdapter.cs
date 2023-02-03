using Talks.C2DF.Interfaces;
using Talks.C2DF.ExternalLoggingLib;
using extLog = Talks.C2DF.ExternalLoggingLib;

namespace Talks.C2DF.BetterAppLib;

public class ExternalLogAdapter : IAppLogger
{
	readonly extLog.ILogger _logger;
    // public ExternalLogAdapter(extLog.ILogger logger)
    public ExternalLogAdapter()
    {
		// _logger = logger ?? throw new ArgumentNullException(nameof(logger), $"{nameof(logger)} is null.");
		_logger = new WhackyLogger();
	}

	public void Debug(string Message)
	{
		_logger.Debug(Message);
	}

	public void Error(string Message)
	{
		_logger.Error(Message);
	}

	public void Info(string Message)
	{
		_logger.Info(Message);
	}

	public void Warn(string Message)
	{
		_logger.Warn(Message);
	}
}
