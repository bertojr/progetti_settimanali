using System.Data.SqlClient;
using _07232024_s6_progetto.Interfaces;
using _07232024_s6_progetto.Models;
using _07232024_s6_progetto.Services;

namespace _07232024_s6_progetto.DAO
{
    public class GuestDao : IDao<Guest>
    {
        private readonly DatabaseHelper _databaseHelper;
        
        private const string INSERT_GUEST =
            "INSERT INTO Guests(CF, FirstName, LastName, CityOfResidence, " +
            "ProvinceOfResidence, Email, Phone, MobilePhone) " +
            "VALUES(@cf, @firstName, @lastName, @cityOfResidence, @provinceOfResidence, " +
            "@email, @phone, @mobilePhone)";
        private const string GETALL_GUESTS =
            "SELECT * " +
            "FROM Guests";
        private const string READ_GUEST =
            "SELECT * " +
            "FROM Guests " +
            "WHERE GuestID = @id";
        private const string UPDATE_GUEST =
            "UPDATE Guests " +
            "SET CF = @cf, FirstName = @firstName, LastName = @lastName, " +
            "CityOfResidence = @cityOfResidence, ProvinceOfResidence = @provinceOfResidence, " +
            "Email = @email, Phone = @phone, MobilePhone = @mobilePhone " +
            "WHERE GuestID = @id";
        private const string DELETE_GUEST =
            "DELETE FROM Guests " +
            "WHERE GuestID = @id";

        public GuestDao(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public Guest Create(Guest newGuest)
        {
            var parameters = new[]
            {
                new SqlParameter("@cf", newGuest.CF),
                new SqlParameter("@firstName", newGuest.FirstName),
                new SqlParameter("@lastName", newGuest.LastName),
                new SqlParameter("@cityOfResidence", string.IsNullOrEmpty
                (newGuest.CityOfResidence)? DBNull.Value : newGuest.CityOfResidence),
                new SqlParameter("@provinceOfResidence", string.IsNullOrEmpty
                (newGuest.ProvinceOfResidence)? DBNull.Value : newGuest.ProvinceOfResidence),
                new SqlParameter("@email", string.IsNullOrEmpty
                (newGuest.Email) ? DBNull.Value : newGuest.Email),
                new SqlParameter("@phone", string.IsNullOrEmpty
                (newGuest.Phone) ? DBNull.Value : newGuest.Phone),
                new SqlParameter("@mobilePhone", string.IsNullOrEmpty
                (newGuest.MobilePhone) ? DBNull.Value : newGuest.MobilePhone)
            };
            _databaseHelper.ExecuteNonQuery(INSERT_GUEST, parameters);
            return newGuest;
        }

        public List<Guest> GetAll()
        {
            return _databaseHelper.ExecuteQuery(GETALL_GUESTS, reader => new Guest
            {
                GuestID = reader.GetInt32(0),
                CF = reader.GetString(1),
                FirstName = reader.GetString(2),
                LastName = reader.GetString(3),
                CityOfResidence = reader.IsDBNull(4) ? "" : reader.GetString(4),
                ProvinceOfResidence = reader.IsDBNull(5) ? "" : reader.GetString(5),
                Email = reader.IsDBNull(6) ? "" : reader.GetString(6),
                Phone = reader.IsDBNull(7) ? "" : reader.GetString(7),
                MobilePhone = reader.IsDBNull(8) ? "" : reader.GetString(8)
            });
        }

        public Guest Read(int id)
        {
            var p = new[]
            {
                new SqlParameter("@id", id)
            };

            var results = _databaseHelper.ExecuteQuery(READ_GUEST, reader => new Guest
            {
                GuestID = reader.GetInt32(0),
                CF = reader.GetString(1),
                FirstName = reader.GetString(2),
                LastName = reader.GetString(3),
                CityOfResidence = reader.IsDBNull(4) ? "" : reader.GetString(4),
                ProvinceOfResidence = reader.IsDBNull(5) ? "" : reader.GetString(5),
                Email = reader.IsDBNull(6) ? "" : reader.GetString(6),
                Phone = reader.IsDBNull(7) ? "" : reader.GetString(7),
                MobilePhone = reader.IsDBNull(8) ? "" : reader.GetString(8)
            });

            return results.FirstOrDefault();
        }

        public Guest Update(Guest guest)
        {
            var p = new[]
            {
                new SqlParameter("@cf", guest.CF),
                new SqlParameter("@firstName", guest.FirstName),
                new SqlParameter("@lastName", guest.LastName),
                new SqlParameter("@cityOfResidence", string.IsNullOrEmpty
                (guest.CityOfResidence)? DBNull.Value : guest.CityOfResidence),
                new SqlParameter("@provinceOfResidence", string.IsNullOrEmpty
                (guest.ProvinceOfResidence)? DBNull.Value : guest.ProvinceOfResidence),
                new SqlParameter("@email", string.IsNullOrEmpty
                (guest.Email) ? DBNull.Value : guest.Email),
                new SqlParameter("@phone", string.IsNullOrEmpty
                (guest.Phone) ? DBNull.Value : guest.Phone),
                new SqlParameter("@mobilePhone", string.IsNullOrEmpty
                (guest.MobilePhone) ? DBNull.Value : guest.MobilePhone)
            };
            _databaseHelper.ExecuteNonQuery(UPDATE_GUEST, p);
            return guest;
        }

        public void Delete(int id)
        {
            var p = new[]
            {
                new SqlParameter("@id", id)
            };
            _databaseHelper.ExecuteNonQuery(DELETE_GUEST, p);
        }
    }
}

