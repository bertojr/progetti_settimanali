using System;
using _07232024_s6_progetto.Models;
using _07232024_s6_progetto.Services;
using System.Data.SqlClient;
using _07232024_s6_progetto.Interfaces;

namespace _07232024_s6_progetto.DAO
{
	public class UserDao : IDao<User>
	{
        private readonly DatabaseHelper _databaseHelper;

        private const string INSERT_USER =
            "INSERT INTO Users(FirstName, LastName, Username, Email, PasswordHash, PasswordSalt) " +
            "VALUES(@firstName, @lastName, @username, @email, @passwordHash, @passwordSalt)";
        private const string GET_ALL_USER =
            "SELECT * " +
            "FROM Users";
        private const string READ_USER =
            "SELECT * " +
            "FROM Users " +
            "WHERE UserID = @id";
        private const string UPDATE_USER =
            "UPDATE Users " +
            "SET FirstName = @firstName, LastName = @lastName, Username = @username, " +
            "Email = @email, PasswordHash = @passwordHash, PasswordSalt = @passwordSalt" +
            "WHERE UserID = @id";
        private const string DELETE_USER =
            "DELETE FROM Users " +
            "WHERE UserID = @id";

        public UserDao(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public User Create(User newUser)
        {
            var p = new[]
            {
                new SqlParameter("@firstName", newUser.FirstName),
                new SqlParameter("@lastName", newUser.LastName),
                new SqlParameter("@username", newUser.Username),
                new SqlParameter("@email", (object)newUser.Email ?? DBNull.Value),
                new SqlParameter("@passwordHash", newUser.PasswordHash),
                new SqlParameter("@passwordSalt", newUser.PasswordSalt),
            };
            _databaseHelper.ExecuteNonQuery(INSERT_USER, p);
            return newUser;
        }

        public User Read(int id)
        {
            var p = new[]
            {
                new SqlParameter("@id", id)
            };

            var results = _databaseHelper.ExecuteQuery(READ_USER, reader => new User
            {
                UserID = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                Username = reader.GetString(3),
                Email = reader.GetString(4),
                PasswordHash = reader.GetString(5),
                PasswordSalt = reader.GetString(6)
            }, p);

            return results.FirstOrDefault();
        }

        public User Update(User user)
        {
            var p = new[]
            {
                new SqlParameter("@firstName", user.FirstName),
                new SqlParameter("@lastName", user.LastName),
                new SqlParameter("@username", user.Username),
                new SqlParameter("@email", user.Email),
                new SqlParameter("@passwordHash", user.PasswordHash),
                new SqlParameter("@passwordSalt", user.PasswordSalt),
            };
            _databaseHelper.ExecuteNonQuery(UPDATE_USER, p);
            return user;
        }

        public void Delete(int id)
        {
            var p = new[]
            {
                new SqlParameter("@id", id)
            };
            _databaseHelper.ExecuteNonQuery(DELETE_USER, p);
        }

        public List<User> GetAll()
        {
            return _databaseHelper.ExecuteQuery(GET_ALL_USER, reader => new User
            {
                UserID = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                Username = reader.GetString(3),
                Email = reader.IsDBNull(4) ? "" : reader.GetString(4),
                PasswordHash = reader.GetString(5),
                PasswordSalt = reader.GetString(6)
            });
        }
    }
}

