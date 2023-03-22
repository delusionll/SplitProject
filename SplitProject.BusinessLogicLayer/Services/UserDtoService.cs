using SplitProject.BLL.DTO;
using SplitProject.BLL.IServices;
using SplitProject.Domain.Models;

namespace SplitProject.BLL.Services
{
    public class UserDtoService : IDtoService<User, UserDTO>
    {
        public UserDTO ToDto(User user)
        {
            return new UserDTO()
            {
                Balance = user.Balance,
                Name = user.Name
            };
        }

        public User ToEntity(UserDTO userDto)
        {
            User entity = new()
            {
                Name = userDto.Name,
                Balance = userDto.Balance
            };
            return entity;
        }
    }
}
