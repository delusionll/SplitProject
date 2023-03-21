using SplitProject.BLL.DTO;
using SplitProject.BLL.IServices;
using SplitProject.Domain.Models;

namespace SplitProject.BLL.Services
{
    internal class UserDtoService : IDtoService<User, UserDTO>
    {
        public UserDTO ToDto(User user)
        {
            return new UserDTO()
            {
                UserBalance = user.UserBalance,
                UserName = user.UserName
            };
        }

        public User ToEntity(UserDTO userDto)
        {
            User entity = new()
            {
                UserName = userDto.UserName,
                UserBalance = userDto.UserBalance
            };
            return entity;
        }
    }
}
