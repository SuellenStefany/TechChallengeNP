using System;
using Microsoft.EntityFrameworkCore;
using TechChallenge.Application.DTOs.UserForm;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces.IUserForm;
using TechChallenge.Infrastructure.Context;

namespace TechChallenge.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region[PROPERTIES]
        private readonly AppDbContext _appDbContext;
        #endregion

        #region[CONSTRUCTOR]
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        #endregion

        #region[METHODS]
        public async Task<List<User>> CreateUser(List<User> user)
        {
            await _appDbContext.AddRangeAsync(user);
            await _appDbContext.SaveChangesAsync();
            return user;
        }
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var result = await _appDbContext.User
                 .Select(u => new UserDto
                 {
                     Id = u.Id,
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     Birthdate = u.Birthdate,
                     Gender = u.Gender,
                     Phone = u.Phone,
                     Email = u.Email,
                 }).ToListAsync();
            return result;
        }
        public async Task<User> GetById(Guid Id)
        {
            return await _appDbContext.User.FirstOrDefaultAsync(u => u.Id == Id);
        }
        public async Task<User> UpdateUser(Guid Id, UpdateUserDto updateUser)
        {
            var existUser = await _appDbContext.User.SingleOrDefaultAsync(exist => exist.Id == Id);
            if (existUser == null)
            {
                return null;
            }
            existUser.UpdateUser(updateUser.FirstName, updateUser.LastName, updateUser.Birthdate, updateUser.Gender, updateUser.Phone, updateUser.Email);
            await _appDbContext.SaveChangesAsync();
            return existUser;
        }
        public async Task DeleteUser(Guid Id)
        {
            var del = await _appDbContext.User.SingleOrDefaultAsync(del => del.Id == Id);
            _appDbContext.User.Remove(del);
            await _appDbContext.SaveChangesAsync();
        }
        #endregion
    }
}
