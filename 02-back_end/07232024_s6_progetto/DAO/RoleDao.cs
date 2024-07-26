using _07232024_s6_progetto.Models;
using _07232024_s6_progetto.Services;
using System.Data.SqlClient;
using _07232024_s6_progetto.Interfaces;

namespace _07232024_s6_progetto.DAO
{
	public class RoleDao : IDao<Role>
	{
        private readonly DatabaseHelper _databaseHelper;

        private const string INSERT_ROLE =
            "INSERT INTO Roles(RoleName) " +
            "VALUES(@roleName)";
        private const string GET_ALL_ROLE =
            "SELECT * " +
            "FROM Roles";
        private const string READ_ROLE =
            "SELECT * " +
            "FROM Roles " +
            "WHERE RoleID = @id";
        private const string UPDATE_ROLE =
            "UPDATE Roles " +
            "SET RoleName = @roleName" +
            "WHERE RoleID = @id";
        private const string DELETE_ROLE =
            "DELETE FROM Roles " +
            "WHERE RoleID = @id";

        public RoleDao(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public Role Create(Role newRole)
        {
            var p = new[]
            {
                new SqlParameter("@roleName", newRole.RoleName),

            };
            _databaseHelper.ExecuteNonQuery(INSERT_ROLE, p);
            return newRole;
        }

        public Role Read(int id)
        {
            var p = new[]
            {
                new SqlParameter("@id", id)
            };

            var results = _databaseHelper.ExecuteQuery(READ_ROLE, reader => new Role
            {
                RoleID = reader.GetInt32(0),
                RoleName = reader.GetString(1)
            });

            return results.FirstOrDefault();
        }

        public Role Update(Role role)
        {
            var p = new[]
            {
                new SqlParameter("@roleName", role.RoleName),
            };
            _databaseHelper.ExecuteNonQuery(UPDATE_ROLE, p);
            return role;
        }

        public void Delete(int id)
        {
            var p = new[]
            {
                new SqlParameter("@id", id)
            };
            _databaseHelper.ExecuteNonQuery(DELETE_ROLE, p);
        }

        public List<Role> GetAll()
        {
            return _databaseHelper.ExecuteQuery(GET_ALL_ROLE, reader => new Role
            {
                RoleID = reader.GetInt32(0),
                RoleName = reader.GetString(1)
            });
        }
    }
}

