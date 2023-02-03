using System.Collections.Generic;

namespace Talks.C2DF.ExternalLoggingLib;

public class WhackyLogger : ILogger
{
    private IList<LogEntry> _logs;

    public WhackyLogger()
    {
        _logs = new List<LogEntry>();
    }

    public bool Enabled(LogType type)
    {
        return true;
    }

    public IList<LogEntry> GetEntries()
    {
        return _logs;
    }

    public void Log(LogEntry logEntry)
    {
        _logs.Add(logEntry);
    }
}
