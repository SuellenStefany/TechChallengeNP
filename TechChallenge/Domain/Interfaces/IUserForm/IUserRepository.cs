using TechChallenge.Application.DTOs.UserForm;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces.IUserForm
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetAll();
        Task<User> GetById(Guid Id);
        Task<List<User>> CreateUser(List<User> user);
        Task<User> UpdateUser(Guid Id, UpdateUserDto updateUser);
        Task DeleteUser(Guid Id);
    }
}
