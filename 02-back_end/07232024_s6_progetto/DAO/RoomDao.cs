using System;
using _07232024_s6_progetto.Models;
using _07232024_s6_progetto.Services;
using System.Data.SqlClient;
using _07232024_s6_progetto.Interfaces;

namespace _07232024_s6_progetto.DAO
{
	public class RoomDao : IDao<Room>
    {
        private readonly DatabaseHelper _databaseHelper;

        private const string INSERT_ROOM =
            "INSERT INTO Rooms(Description, Typology) " +
            "VALUES(@description, @typology)";
        private const string GET_ALL_ROOM =
            "SELECT * " +
            "FROM Rooms";
        private const string READ_ROOM =
            "SELECT * " +
            "FROM Rooms " +
            "WHERE RoomID = @id";
        private const string UPDATE_ROOM =
            "UPDATE Rooms " +
            "SET Description = @description, Typology = @typology" +
            "WHERE RoomID = @id";
        private const string DELETE_ROOM =
            "DELETE FROM Rooms " +
            "WHERE RoomID = @id";

        public RoomDao(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public Room Create(Room newRoom)
        {
            var p = new[]
            {
                new SqlParameter("@description", newRoom.Description),
                new SqlParameter("@typology", newRoom.Typology),
            };
            _databaseHelper.ExecuteNonQuery(INSERT_ROOM, p);
            return newRoom;
        }

        public Room Read(int id)
        {
            var p = new[]
            {
                new SqlParameter("@id", id)
            };

            var results = _databaseHelper.ExecuteQuery(READ_ROOM, reader => new Room
            {
                RoomID = reader.GetInt32(0),
                Description = reader.GetString(1),
                Typology = reader.GetString(2)
            });

            return results.FirstOrDefault();
        }

        public Room Update(Room room)
        {
            var p = new[]
            {
                new SqlParameter("@description", room.Description),
                new SqlParameter("@typology", room.Typology),
            };
            _databaseHelper.ExecuteNonQuery(UPDATE_ROOM, p);
            return room;
        }

        public void Delete(int id)
        {
            var p = new[]
            {
                new SqlParameter("@id", id)
            };
            _databaseHelper.ExecuteNonQuery(DELETE_ROOM, p);
        }

        public List<Room> GetAll()
        {
            return _databaseHelper.ExecuteQuery(GET_ALL_ROOM, reader => new Room
            {
                RoomID = reader.GetInt32(0),
                Description = reader.GetString(1),
                Typology = reader.GetString(2)
            });
        }
    }
}

