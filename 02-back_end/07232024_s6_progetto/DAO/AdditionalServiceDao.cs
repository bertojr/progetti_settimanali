using System;
using System.Data.SqlClient;
using _07232024_s6_progetto.Interfaces;
using _07232024_s6_progetto.Models;
using _07232024_s6_progetto.Services;

namespace _07232024_s6_progetto.DAO
{
	public class AdditionalServiceDao : IDao<AdditionalService>
	{
        private readonly DatabaseHelper _databaseHelper;

        private const string INSERT_ADDITIONAL_SERVICE =
            "INSERT INTO AdditionalServices(Description, Price) " +
            "VALUES(@description, @price)";
        private const string GET_ALL_ADDITIONAL_SERVICES =
            "SELECT * " +
            "FROM AdditionalServices";
        private const string READ_ADDITIONAL_SERVICE =
            "SELECT * " +
            "FROM AdditionalServices " +
            "WHERE AdditionalServicesID = @id";
        private const string UPDATE_ADDITIONAL_SERVICE =
            "UPDATE AdditionalServices " +
            "SET Description = @description, Price = @price " +
            "WHERE AdditionalServicesID = @id";
        private const string DELETE_ADDITIONAL_SERVICE =
            "DELETE FROM AdditionalServices " +
            "WHERE AdditionalServicesID = @id";

        public AdditionalServiceDao(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public AdditionalService Create(AdditionalService newService)
        {
            var p = new[]
            {
                new SqlParameter("@description", newService.Description),
                new SqlParameter("@firstName", newService.Price),
            };
            _databaseHelper.ExecuteNonQuery(INSERT_ADDITIONAL_SERVICE, p);
            return newService;
        }

        public AdditionalService Read(int id)
        {
            var p = new[]
            {
                new SqlParameter("@id", id)
            };

            var results = _databaseHelper.ExecuteQuery(READ_ADDITIONAL_SERVICE, reader => new AdditionalService
            {
                AdditionalServiceID = reader.GetInt32(0),
                Description = reader.GetString(1),
                Price = reader.GetDecimal(2),
            });

            return results.FirstOrDefault();
        }

        public AdditionalService Update(AdditionalService service)
        {
            var p = new[]
            {
                new SqlParameter("@description", service.Description),
                new SqlParameter("@price", service.Price),
            };
            _databaseHelper.ExecuteNonQuery(UPDATE_ADDITIONAL_SERVICE, p);
            return service;
        }

        public void Delete(int id)
        {
            var p = new[]
            {
                new SqlParameter("@id", id)
            };
            _databaseHelper.ExecuteNonQuery(DELETE_ADDITIONAL_SERVICE, p);
        }

        public List<AdditionalService> GetAll()
        {
            return _databaseHelper.ExecuteQuery(GET_ALL_ADDITIONAL_SERVICES, reader => new AdditionalService
            {
                AdditionalServiceID = reader.GetInt32(0),
                Description = reader.GetString(1),
                Price = reader.GetDecimal(2),
            });
        }
    }
}

