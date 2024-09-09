namespace Domain.Models;

using System;

/// <summary>
/// Log class.
/// </summary>
public class SqlLog
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SqlLog"/> class.
    /// </summary>
    public SqlLog()
    {
    }

    /// <summary>
    /// Gets or sets log ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets command message.
    /// </summary>
    public string CommandMessage { get; set; }

    /// <summary>
    /// Gets or sets time stamp.
    /// </summary>
    public DateTime TimeStamp { get; set; }
}
