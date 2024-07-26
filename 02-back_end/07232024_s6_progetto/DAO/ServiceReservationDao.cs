using System;
using _07232024_s6_progetto.Models;
using _07232024_s6_progetto.Services;
using System.Data.SqlClient;
using _07232024_s6_progetto.Interfaces;

namespace _07232024_s6_progetto.DAO
{
	public class ServiceReservationDao : IDao<ServiceReservation>
	{
        private readonly DatabaseHelper _databaseHelper;

        private const string INSERT_SERVICE_RESERVATION =
            "INSERT INTO ServiceReservations(ReservationID, AdditionalServiceID, Date, Quantity, TotalPrice) " +
            "VALUES(@reservationId, @additionalService, @date, @quantity, @totalPrice)";
        private const string GET_ALL_SERVICE_RESERVATION =
            "SELECT * " +
            "FROM ServiceReservations as sr " +
                "JOIN Reservations as r " +
                    "ON sr.ReservationID = r.ReservationID " +
                "JOIN AdditionalServices as a " +
                    "ON sr.AdditionalServiceID = a.AdditionalServicesID";
        private const string READ_SERVICE_RESERVATION =
            "SELECT * " +
            "FROM ServiceReservations as sr " +
                "JOIN Reservations as r " +
                    "ON sr.ReservationID = r.ReservationID " +
                "JOIN AdditionalServices as a " +
                    "ON sr.AdditionalServiceID = a.AdditionalServicesID " +
            "WHERE ServiceReservationID = @id";
        private const string UPDATE_SERVICE_RESERVATION =
            "UPDATE ServiceReservations " +
            "SET ReservationID = @reservationId, AdditionalServiceID = @additionalService, " +
            "Date = @date, Quantity = @quantity, TotalPrice = @totalPrice" +
            "WHERE ServiceReservationID = @id";
        private const string DELETE_SERVICE_RESERVATION =
            "DELETE FROM ServiceReservations " +
            "WHERE ServiceReservationID = @id";

        public ServiceReservationDao(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public ServiceReservation Create(ServiceReservation newServiceReservatio)
        {
            var p = new[]
            {
                new SqlParameter("@reservationId", newServiceReservatio.ReservationID),
                new SqlParameter("@additionalService", newServiceReservatio.AdditionalServiceID),
                new SqlParameter("@date", newServiceReservatio.Date),
                new SqlParameter("@quantity", newServiceReservatio.Quantity),
                new SqlParameter("@totalPrice", newServiceReservatio.TotalPrice),
            };
            _databaseHelper.ExecuteNonQuery(INSERT_SERVICE_RESERVATION, p);
            return newServiceReservatio;
        }

        public ServiceReservation Read(int id)
        {
            var p = new[]
            {
                new SqlParameter("@id", id)
            };

            var results = _databaseHelper.ExecuteQuery(READ_SERVICE_RESERVATION, reader => new ServiceReservation
            {
                ServiceReservationID = reader.GetInt32(0),
                ReservationID = reader.GetInt32(1),
                AdditionalServiceID = reader.GetInt32(2),
                Date = reader.GetDateTime(3),
                Quantity = reader.GetInt32(4),
                TotalPrice = reader.GetDecimal(5),
                Reservation = new Reservation
                {
                    ReservationID = reader.GetInt32(6),
                    CF = reader.GetString(7),
                    RoomID = reader.GetInt32(8),
                    ReservationDate = reader.GetDateTime(9),
                    Year = reader.GetInt32(10),
                    CheckinDate = DateOnly.FromDateTime(reader.GetDateTime(11)),
                    CheckoutDate = DateOnly.FromDateTime(reader.GetDateTime(12)),
                    ConfirmationDeposit = reader.GetDecimal(13),
                    Rate = reader.GetInt32(14),
                    Details = reader.GetString(15)
                },
                AdditionalService = new AdditionalService
                {
                    AdditionalServiceID = reader.GetInt32(16),
                    Description = reader.GetString(17),
                    Price = reader.GetDecimal(18)
                }
            }, p);

            return results.FirstOrDefault();
        }

        public ServiceReservation Update(ServiceReservation serviceReservation)
        {
            var p = new[]
            {
                new SqlParameter("@reservationId", serviceReservation.ReservationID),
                new SqlParameter("@additionalService", serviceReservation.AdditionalService),
                new SqlParameter("@date", serviceReservation.Date),
                new SqlParameter("@quantity", serviceReservation.Quantity),
                new SqlParameter("@totalPrice", serviceReservation.TotalPrice),
                new SqlParameter("@id", serviceReservation.ServiceReservationID),
            };
            _databaseHelper.ExecuteNonQuery(UPDATE_SERVICE_RESERVATION, p);
            return serviceReservation;
        }

        public void Delete(int id)
        {
            var p = new[]
            {
                new SqlParameter("@id", id)
            };
            _databaseHelper.ExecuteNonQuery(DELETE_SERVICE_RESERVATION, p);
        }

        public List<ServiceReservation> GetAll()
        {
            return _databaseHelper.ExecuteQuery(GET_ALL_SERVICE_RESERVATION, reader => new ServiceReservation
            {
                ServiceReservationID = reader.GetInt32(0),
                ReservationID = reader.GetInt32(1),
                AdditionalServiceID = reader.GetInt32(2),
                Date = reader.GetDateTime(3),
                Quantity = reader.GetInt32(4),
                TotalPrice = reader.GetDecimal(5),
                Reservation = new Reservation
                {
                    ReservationID = reader.GetInt32(6),
                    CF = reader.GetString(7),
                    RoomID = reader.GetInt32(8),
                    ReservationDate = reader.GetDateTime(9),
                    Year = reader.GetInt32(10),
                    CheckinDate = DateOnly.FromDateTime(reader.GetDateTime(11)),
                    CheckoutDate = DateOnly.FromDateTime(reader.GetDateTime(12)),
                    ConfirmationDeposit = reader.GetDecimal(13),
                    Rate = reader.GetInt32(14),
                    Details = reader.GetString(15)
                },
                AdditionalService = new AdditionalService
                {
                    AdditionalServiceID = reader.GetInt32(16),
                    Description = reader.GetString(17),
                    Price = reader.GetDecimal(18)
                }
            });
        }
    }
}

