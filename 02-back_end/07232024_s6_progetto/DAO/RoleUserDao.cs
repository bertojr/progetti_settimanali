using System;
using _07232024_s6_progetto.Models;
using _07232024_s6_progetto.Services;
using System.Data.SqlClient;
using _07232024_s6_progetto.Interfaces;

namespace _07232024_s6_progetto.DAO
{
	public class RoleUserDao : IDao<RoleUser>
    {
        private readonly DatabaseHelper _databaseHelper;

        private const string INSERT_ROLEUSER =
            "INSERT INTO RolesUsers(UserID, RoleID) " +
            "VALUES(@userId, @roleId)";
        private const string GET_ALL_ROLEUSER =
            "SELECT * " +
            "FROM RolesUsers as r " +
                "JOIN Users as u " +
                    "ON r.UserID = u.UserID " +
                "JOIN Roles as ro " +
                    "ON ro.RoleID = r.RoleID";
        private const string READ_ROLEUSER =
            "SELECT * " +
            "FROM RolesUsers as r " +
                "JOIN Users as u " +
                    "ON r.UserID = u.UserID " +
                "JOIN Roles as ro " +
                    "ON ro.RoleID = r.RoleID " +
            "WHERE UserID = @userId";
        private const string UPDATE_ROLEUSER =
            "UPDATE RolesUsers " +
            "SET UserID = @userId, RoleID = @roleId" +
            "WHERE UserID = @id";
        private const string DELETE_ROLEUSER =
            "DELETE FROM RolesUsers " +
            "WHERE UserID = @id";

        public RoleUserDao(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public RoleUser Create(RoleUser newRoleUser)
        {
            var p = new[]
            {
                new SqlParameter("@userId", newRoleUser.UserID),
                new SqlParameter("@roleId", newRoleUser.RoleID),

            };
            _databaseHelper.ExecuteNonQuery(INSERT_ROLEUSER, p);
            return newRoleUser;
        }

        public RoleUser Read(int id)
        {
            var p = new[]
            {
                new SqlParameter("@id", id)
            };

            var results = _databaseHelper.ExecuteQuery(READ_ROLEUSER, reader => new RoleUser
            {
                UserID = reader.GetInt32(0),
                RoleID = reader.GetInt32(1),
                User = new User
                {
                    UserID = reader.GetInt32(2),
                    FirstName = reader.GetString(3),
                    LastName = reader.GetString(5),
                    Username = reader.GetString(6),
                    Email = reader.GetString(7),
                    PasswordHash = reader.GetString(8),
                    PasswordSalt = reader.GetString(9),
                },
                Role = new Role
                {
                    RoleID = reader.GetInt32(10),
                    RoleName = reader.GetString(11),
                }
            });

            return results.FirstOrDefault();
        }

        public RoleUser Update(RoleUser roleUser)
        {
            var p = new[]
            {
                new SqlParameter("@userId", roleUser.UserID),
                new SqlParameter("@roleId", roleUser.RoleID),
            };
            _databaseHelper.ExecuteNonQuery(UPDATE_ROLEUSER, p);
            return roleUser;
        }

        public void Delete(int id)
        {
            var p = new[]
            {
                new SqlParameter("@id", id)
            };
            _databaseHelper.ExecuteNonQuery(DELETE_ROLEUSER, p);
        }

        public List<RoleUser> GetAll()
        {
            return _databaseHelper.ExecuteQuery(GET_ALL_ROLEUSER, reader => new RoleUser
            {
                UserID = reader.GetInt32(0),
                RoleID = reader.GetInt32(1),
                User = new User
                {
                    UserID = reader.GetInt32(2),
                    FirstName = reader.GetString(3),
                    LastName = reader.GetString(5),
                    Username = reader.GetString(6),
                    Email = reader.GetString(7),
                    PasswordHash = reader.GetString(8),
                    PasswordSalt = reader.GetString(9),
                },
                Role = new Role
                {
                    RoleID = reader.GetInt32(10),
                    RoleName = reader.GetString(11),
                }
            });
        }
    }
}

