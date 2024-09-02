namespace SplitWinClient;

using System;
using System.Diagnostics;

using Microsoft.Extensions.Logging;
internal class ApiClientLogger : ILogger
{
    public void Log<TState>(LogLevel logLevel,
                            EventId eventId,
                            TState state,
                            Exception? exception,
                            Func<TState, Exception?, string> formatter)
    {
        Debug.WriteLine($"{logLevel}, {eventId}, {state}, {exception}, {formatter}");
    }

    public bool IsEnabled(LogLevel logLevel) => throw new NotImplementedException();

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => throw new NotImplementedException();
}
