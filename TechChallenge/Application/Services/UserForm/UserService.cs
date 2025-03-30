using TechChallenge.Application.DTOs.UserForm;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.IExternalServices;
using TechChallenge.Domain.Interfaces.IUserForm;

namespace TechChallenge.Application.Services.UserForm
{
    public class UserService : IUserService
    {
        #region[PROPERTIES]
        private readonly IUserRepository _userRepository;
        private readonly IRandomUserService _randomUserService;
        #endregion

        #region[CONSTRUCTOR]
        public UserService(IUserRepository userRepository, IRandomUserService randomUserService)
        {
            _userRepository = userRepository;
            _randomUserService = randomUserService;
        }
        #endregion

        #region[METHODS]
        public async Task<List<User>> CreateUser(CreateUserDto createUser)
        {
            var resultUser = await _randomUserService.GetUserRandom(createUser);
            return await _userRepository.CreateUser(resultUser);
        }
        public Task<IEnumerable<UserDto>> GetAll()
        {
            return _userRepository.GetAll();
        }
        public async Task<User> GetById(Guid Id)
        {
            return await _userRepository.GetById(Id);
        }
        public Task<User> UpdateUser(Guid Id, UpdateUserDto updateUser)
        {
            return _userRepository.UpdateUser(Id, updateUser);
        }
        public async Task DeleteUser(Guid Id)
        {
            await _userRepository.DeleteUser(Id);
        }
        #endregion
    }
}
