using System;
using _08022024_s7_progetto.DataModels;
using _08022024_s7_progetto.Models;

namespace _08022024_s7_progetto.Interfaces
{
	public interface IAuthService
	{
		public User Register(UserDto userDto);
		public User Login(string username, string password);
	}
}

