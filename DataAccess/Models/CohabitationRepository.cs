using DataAccess.Models.Interface;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Npgsql;
using System;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class CohabitationRepository : ICohabitationRepository
    {
        // private readonly ApplicationContext _db;
        private readonly ApplicationContextSQL _db;

        // public CohabitationRepository(ApplicationContext db) => _db = db;
        public CohabitationRepository(ApplicationContextSQL db) => _db = db;

        public async Task<Cohabitation[]> AddCohabitation(Cohabitation cohabitation)
        {

            // TODO university распарсить => university == СамГТУ => UniversityId = 1; also district
            string commandText = $"INSERT INTO Users (FIO, UniversityID, Age, Pay, Course, Phone, Email, DistrictID, Gender, Description)" +
                                   "values('{cohabitation.FIO}', 1, {cohabitation.Age}, {cohabitation.Pay}, {cohabitation.Course}, '{cohabitation.Phone}'," +
                                   " '{cohabitation.Email}', 1, '{cohabitation.Gender}', '{cohabitation.Description}')";
            await using (SqlCommand sqlCommand = new()
            {
                CommandText = commandText,
                Connection = _db.Connection
            })
                await sqlCommand.ExecuteNonQueryAsync();
            

            return await GetArray();
        }

        private async Task<Cohabitation[]> GetArray()
        {
            SqlCommand commandCount = new("select count(UsersID) from Users", _db.Connection);
            SqlDataReader readerForCount = await commandCount.ExecuteReaderAsync();
            Cohabitation[] array = new Cohabitation[(int) readerForCount.GetValue(0)];
            Console.WriteLine(array.Length);                                                    // for checking

            SqlCommand command = new("SELECT * FROM Users", _db.Connection);
            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                                                                                                // TODO дописать получение всех данных и добавление их в массив
                while (await reader.ReadAsync())
                {
                    object id = reader.GetValue(0);
                    object name = reader.GetValue(2);
                    object age = reader.GetValue(1);

                    Console.WriteLine($"{id} \t{name} \t{age}");
                }
            }

            await reader.CloseAsync();

            return Array.Empty<Cohabitation>();
        }

        public async Task<Cohabitation[]> Delete(string FIO)
        {
            throw new NotImplementedException();
        }

        public async Task<Cohabitation[]> GetCohabitations(Filter filter)
        {
            throw new NotImplementedException();
        }

        public async Task<Cohabitation[]> Insert(Cohabitation cohabitation)
        {
            throw new NotImplementedException();
        }
    }
}
