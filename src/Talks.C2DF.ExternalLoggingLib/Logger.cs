using System;
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
public class Logger : ILogger
{
    private int logId;
    private IList<LogEntry> _logs;

    public Logger()
    {
        logId = 0;
        _logs = new List<LogEntry>();
    }
    // Used for Hard coded singleton
    private static ILogger _instance = null;
    public static ILogger Instance()
    {
        if (_instance == null)
        {
            _instance = new Logger();
        }

        return _instance;
    }

    public bool Enabled(LogType type)
    {
        return true;
    }

    public void Log(LogEntry logEntry)
    {
        Console.WriteLine($"Ext Logger -{logEntry.LogType}- ({logId++}): {logEntry.Message}");
        _logs.Add(logEntry);
    }

    public IList<LogEntry> GetEntries()
    {
        return _logs;
    }
}
