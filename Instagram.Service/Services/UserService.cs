using Instagram.Data.IRepositories;
using Instagram.Domain.Models;
using Instagram.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Service.Services
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> CreateAsync(User user)
        {
            return _userRepository.CreateAsync(user);
        }

        public Task<bool> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            return _userRepository.DeleteAsync(expression);
        }

        public Task<IQueryable<User>> GetAllAsync(Expression<Func<User, bool>> expression)
        {
            return _userRepository.GetAllAsync(expression);
        }

        public Task<User> GetAsync(Expression<Func<User, bool>> expression)
        {
            return _userRepository.GetAsync(expression);
        }

        public Task<User> UpdateAsync(User user)
        {
            return _userRepository.UpdateAsync(user);
        }
    }
}
