using Instagram.Domain.Models;
using Instagram.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Service.Interfaces
{
    public interface IUserService
    {
        Task<IQueryable<User>> GetAllAsync(Expression<Func<User, bool>> expression = null);
        Task<User> GetAsync(Expression<Func<User, bool>> expression);
        Task<bool> DeleteAsync(Expression<Func<User, bool>> expression);
        Task<User> UpdateAsync(User user);
        Task<User> CreateAsync(User user);
        //Task<UserView> CreateAsync(UserView userView);

    }
}
