using System;
using _07232024_s6_progetto.Models;

namespace _07232024_s6_progetto.Interfaces
{
	public interface IUserService
	{
        User Register(UserDto userDto);
        User Login(string username, string password);
        List<User> GetAllUsers();
        User GetById(int id);
        void Update(User user);
        void Delete(int id);
    }
}

