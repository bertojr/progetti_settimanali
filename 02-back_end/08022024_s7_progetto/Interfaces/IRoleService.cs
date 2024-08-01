using System;
using _08022024_s7_progetto.DataModels;

namespace _08022024_s7_progetto.Interfaces
{
	public interface IRoleService
	{
        public Task<Role> Create(Role newRole);
        public Task<List<Role>> GetAll();
        public Task<Role> GetById(int id);
        public Task<Role> Update(int id, Role updateRole);
        public Task<Role> Delete(int id);
    }
}

