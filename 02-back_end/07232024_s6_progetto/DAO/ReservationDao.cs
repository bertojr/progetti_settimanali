using System;
using _07232024_s6_progetto.Models;
using _07232024_s6_progetto.Services;
using System.Data.SqlClient;
using _07232024_s6_progetto.Interfaces;

namespace _07232024_s6_progetto.DAO
{
	public class ReservationDao : IDao<Reservation>
	{
        private readonly DatabaseHelper _databaseHelper;

        private const string INSERT_RESERVATION =
            "INSERT INTO Reservations(CF, RoomID, ReservationDate, Year, CheckInDate, " +
            "CheckOutDate, ConfirmationDeposit, Rate, Details) " +
            "VALUES(@cf, @roomId, @reservationDate, @year, @ckeckIn, @checkOut, " +
            "@confirmationDeposit, @rate, @details)";
        private const string GET_ALL_RESERVATION =
            "SELECT * " +
            "FROM Reservations as r " +
                "JOIN Guests as g " +
                    "ON r.CF = g.CF " +
                "JOIN Rooms as ro " +
                    "ON r.RoomID = ro.RoomID";
        private const string READ_RESERVATION =
            "SELECT * " +
            "FROM Reservations as r " +
                "JOIN Guests as g " +
                    "ON r.CF = g.CF " +
                "JOIN Rooms as ro " +
                    "ON r.RoomID = ro.RoomID " +
            "WHERE ReservationID = @id";
        private const string UPDATE_RESERVATION =
            "UPDATE Reservations " +
            "SET CF = @cf, RoomID = @roomId, ReservationDate = @reservationDate, " +
            "Year = @year, CheckInDate = @ckeckInDate, CheckOutDate = @checkOutDate, " +
            "ConfirmationDeposit = @confirmationDeposit, Rate = @rate, Details = @details " +
            "WHERE ReservationID = @id";
        private const string DELETE_RESERVATION =
            "DELETE FROM Reservations " +
            "WHERE ReservationID = @id";

        public ReservationDao(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public Reservation Create(Reservation newReservation)
        {
            var p = new[]
            {
                new SqlParameter("@cf", newReservation.CF),
                new SqlParameter("@roomId", newReservation.RoomID),
                new SqlParameter("@reservationDate", newReservation.ReservationDate),
                new SqlParameter("@year", newReservation.Year),
                new SqlParameter("@ckeckIn", newReservation.CheckinDate.ToDateTime(TimeOnly.MinValue)),
                new SqlParameter("@checkOut", newReservation.CheckoutDate.ToDateTime(TimeOnly.MinValue)),
                new SqlParameter("@ConfirmationDeposit", newReservation.ConfirmationDeposit),
                new SqlParameter("@rate", newReservation.Rate),
                new SqlParameter("@details", string.IsNullOrEmpty(newReservation.Details)
                ? DBNull.Value : newReservation.Details),

            };
            _databaseHelper.ExecuteNonQuery(INSERT_RESERVATION, p);
            return newReservation;
        }

        public Reservation Read(int id)
        {
            var p = new[]
            {
                new SqlParameter("@id", id)
            };

            var results = _databaseHelper.ExecuteQuery(READ_RESERVATION, reader => new Reservation
            {
                ReservationID = reader.GetInt32(0),
                CF = reader.GetString(1),
                RoomID = reader.GetInt32(2),
                ReservationDate = reader.GetDateTime(3),
                Year = reader.GetInt32(4),
                CheckinDate = DateOnly.FromDateTime(reader.GetDateTime(5)),
                CheckoutDate = DateOnly.FromDateTime(reader.GetDateTime(6)),
                ConfirmationDeposit = reader.GetDecimal(7),
                Rate = reader.GetDecimal(8),
                Details = reader.GetString(9),
                Guest = new Guest
                {
                    GuestID = reader.GetInt32(10),
                    CF = reader.GetString(11),
                    FirstName = reader.GetString(12),
                    LastName = reader.GetString(13),
                    CityOfResidence = reader.IsDBNull(14) ? "" : reader.GetString(14),
                    ProvinceOfResidence = reader.IsDBNull(15) ? "" : reader.GetString(15),
                    Email = reader.IsDBNull(16) ? "" : reader.GetString(16),
                    Phone = reader.IsDBNull(17) ? "" : reader.GetString(17),
                    MobilePhone = reader.IsDBNull(18) ? "" : reader.GetString(18),
                },
                Room = new Room
                {
                    RoomID = reader.GetInt32(19),
                    Description = reader.IsDBNull(20) ? "" : reader.GetString(20),
                    Typology = reader.GetString(21),
                }
            }, p);

            return results.FirstOrDefault();
        }

        public Reservation Update(Reservation reservation)
        {
            var p = new[]
            {
                new SqlParameter("@cf", reservation.CF),
                new SqlParameter("@roomId", reservation.RoomID),
                new SqlParameter("@reservationDate", reservation.ReservationDate),
                new SqlParameter("@year", reservation.Year),
                new SqlParameter("@CheckInDate", reservation.CheckinDate),
                new SqlParameter("@checkOutDate", reservation.CheckoutDate),
                new SqlParameter("@ConfirmationDeposit", reservation.ConfirmationDeposit),
                new SqlParameter("@rate", reservation.Rate),
                new SqlParameter("@details", string.IsNullOrEmpty(reservation.Details)
                ? DBNull.Value : reservation.Details),
            };
            _databaseHelper.ExecuteNonQuery(UPDATE_RESERVATION, p);
            return reservation;
        }

        public void Delete(int id)
        {
            var p = new[]
            {
                new SqlParameter("@id", id)
            };
            _databaseHelper.ExecuteNonQuery(DELETE_RESERVATION, p);
        }

        public List<Reservation> GetAll()
        {
            return _databaseHelper.ExecuteQuery(GET_ALL_RESERVATION, reader => new Reservation
            {
                ReservationID = reader.GetInt32(0),
                CF = reader.GetString(1),
                RoomID = reader.GetInt32(2),
                ReservationDate = reader.GetDateTime(3),
                Year = reader.GetInt32(4),
                CheckinDate = DateOnly.FromDateTime(reader.GetDateTime(5)),
                CheckoutDate = DateOnly.FromDateTime(reader.GetDateTime(6)),
                ConfirmationDeposit = reader.GetDecimal(7),
                Rate = reader.GetDecimal(8),
                Details = reader.GetString(9),
                Guest = new Guest
                {
                    GuestID = reader.GetInt32(10),
                    CF = reader.GetString(11),
                    FirstName = reader.GetString(12),
                    LastName = reader.GetString(13),
                    CityOfResidence = reader.IsDBNull(14) ? "" : reader.GetString(14),
                    ProvinceOfResidence = reader.IsDBNull(15) ? "" : reader.GetString(15),
                    Email = reader.IsDBNull(16) ? "" : reader.GetString(16),
                    Phone = reader.IsDBNull(17) ? "" : reader.GetString(17),
                    MobilePhone = reader.IsDBNull(18) ? "" : reader.GetString(18),
                },
                Room = new Room
                {
                    RoomID = reader.GetInt32(19),
                    Description = reader.IsDBNull(20) ? "" : reader.GetString(20),
                    Typology = reader.GetString(21),
                }
            });
        }
    }
}


