using System;
using _08022024_s7_progetto.DataModels;

namespace _08022024_s7_progetto.Interfaces
{
	public interface IUserService
	{
        public Task<User> Create(User newUser);
        public Task<List<User>> GetAll();
        public Task<User> GetById(int id);
        public Task<User> Update(int id, User updateProduct);
        public Task<User> Delete(int id);
        public Task<User> GetByUsername(string username);
    }
}

