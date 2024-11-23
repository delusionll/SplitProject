namespace DAL;

using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;

public class ContextInterceptor : DbCommandInterceptor
{
    /// <inheritdoc/>
    public override async ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result,
        CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"INTERCEPTOR, EXECUTING COMMAND: {command.CommandText}");

        var re = await base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
        return re;
    }
}