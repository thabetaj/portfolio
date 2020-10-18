using Portfolio.Data;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Repositories
{
    public interface IUserRepository
    {
        public Task<List<User>> Add(UserDto userDto);
        public UserDto getUserSkills(string id);
        public UserDto UpdateUser(string Id);
        public void UpdateUser(UserDto user);
        public User getViewUser(string Id);
        List<User> GetAllUser();
    }
}
