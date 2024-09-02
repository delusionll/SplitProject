namespace SplitProject.BLL.DTO;

using System;

/// <summary>
/// User DTO.
/// </summary>
public class UserDTO
{
    /// <summary>
    /// Gets userID.
    /// </summary>
    public Guid UserID { get; }

    /// <summary>
    /// Gets user Balance.
    /// </summary>
    public decimal Balance { get; }

    /// <summary>
    /// Gets user Name.
    /// </summary>
    public string? Name { get; }
}