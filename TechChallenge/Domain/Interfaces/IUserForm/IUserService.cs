using TechChallenge.Application.DTOs.UserForm;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces.IUserForm
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<User> GetById(Guid Id);
        Task<List<User>> CreateUser(CreateUserDto createUser);
        Task<User> UpdateUser(Guid Id, UpdateUserDto updateUser);
        Task DeleteUser(Guid Id);
    }
}
