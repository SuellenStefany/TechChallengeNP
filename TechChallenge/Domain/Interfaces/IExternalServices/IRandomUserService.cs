using TechChallenge.Application.DTOs.UserForm;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces.IExternalServices
{
    public interface IRandomUserService
    {
        Task<List<User>> GetUserRandom(CreateUserDto createUser);
    }
}
