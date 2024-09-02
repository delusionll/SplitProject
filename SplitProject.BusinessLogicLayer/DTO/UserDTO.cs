using System;

namespace SplitProject.BLL.DTO;

public class UserDTO
{
    public Guid Id { get; set; }
    public decimal Balance { get; set; } = 0;

    public string? Name { get; set; }
}