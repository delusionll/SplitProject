namespace SplitProject.BLL.DTO;

using System;

/// <summary>
/// User DTO.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UserDTO"/> class.
/// </remarks>
/// <param name="userID">ID.</param>
/// <param name="balance">Balance.</param>
/// <param name="name">Name.</param>
public class UserDTO(Guid userID, decimal balance, string? name)
{

    /// <summary>
    /// Gets userID.
    /// </summary>
    public Guid UserID { get; } = userID;

    /// <summary>
    /// Gets user Balance.
    /// </summary>
    public decimal Balance { get; } = balance;

    /// <summary>
    /// Gets user Name.
    /// </summary>
    public string? Name { get; } = name;
}