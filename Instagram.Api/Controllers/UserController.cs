using AutoMapper;
using Instagram.Domain.Models;
using Instagram.Service.Interfaces;
using Instagram.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Instagram.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Create")]
        public Task<User> Create(User user)
        {
            //var entity = await _userService.CreateAsync(userView);

            //User user = new User()
            //{
            //    Id = entity.Id,
            //    UserName = entity.UserName,
            //    Password = entity.Password,
            //    Email = entity.Email,
            //    PhoneNumber = entity.PhoneNumber,
            //    Bio = entity.Bio,
            //};

            return _userService.CreateAsync(user);
        }

        [HttpGet("{id}")]
        public Task<User> Get(long id)
        {
            return _userService.GetAsync(p => p.Id.Equals(id));
        }

        [HttpGet("All")]
        public Task<IQueryable<User>> GetAll(Expression<Func<User, bool>> expression = null)
        {
            return _userService.GetAllAsync(expression);
        }

        [HttpPatch("Update")] 
        public Task<User> Update(User user)
        {
            return _userService.UpdateAsync(user);
        }

        [HttpDelete("Delete")]
        public Task<bool> Delete(long id)
        {
            return _userService.DeleteAsync(p => p.Id.Equals(id));
        }
    }
}
