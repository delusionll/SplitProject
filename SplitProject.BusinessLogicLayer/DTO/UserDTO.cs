using SplitProject.Domain.Models;

namespace SplitProject.BLL.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string? UserName { get; set; }
        public decimal UserBalance { get; set; }
    }
}
