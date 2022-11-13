using DataAccess.Models.Interface;

using Domain.Models;

using Microsoft.Data.SqlClient;

using System;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class CohabitationRepository : ICohabitationRepository
    {
        private readonly ApplicationContextSQL _db;

        public CohabitationRepository (ApplicationContextSQL db) => _db = db;

        // Добавление пользователя
        public async Task<Cohabitation[]> AddCohabitation (Cohabitation cohabitation)
        {
            var univerId = int.Parse(cohabitation.University);
            var district = int.Parse(cohabitation.District);
            string commandText = string.Format("INSERT INTO Users " +
                "(FIO, UniversityID, Age, Pay, Course, Phone, Email, DistrictID, Gender, UserDescription, UserPassword, LinkToTelegram, LinkToVk)\n" +
                "values('{0}', {1}, {2}, {3}, {4}, '{5}', '{6}', {7}, '{8}', '{9}', '{10}', '{11}', '{12}')",
                cohabitation.FIO, univerId, cohabitation.Age, cohabitation.Pay, cohabitation.Course, cohabitation.Phone,
                cohabitation.Email, district, cohabitation.Gender, cohabitation.Description, cohabitation.Password, cohabitation.LinkToTelegram, cohabitation.LinkToVk);

            await using (SqlCommand sqlCommand = new()
            {
                CommandText = commandText,
                Connection = _db.Connection
            })
                await sqlCommand.ExecuteNonQueryAsync();

            return await GetArrayCohabitations();
        }

        public async Task<Cohabitation[]> Delete (string FIO)
        {
            throw new NotImplementedException();
        }

        public async Task<Cohabitation[]> GetCohabitations (Filter filter)
        {
            throw new NotImplementedException();
        }
        public async Task<Cohabitation[]> Insert (Cohabitation cohabitation)
        {
            throw new NotImplementedException();
        }

        // Получение массива пользователей
        public async Task<Cohabitation[]> GetArrayCohabitations ()
        {
            var c = await GetCountCohabition();
            Cohabitation[] array = new Cohabitation[c];

            SqlCommand command = new("select Users.UsersID, Users.FIO, University.UniversityName, Users.Age, Users.Pay, Users.Course,\n" +
                "Users.Phone, Users.Email, District.DistrictName, Users.Gender, Users.UserDescription,  Users.UserPassword, Users.LinkToTelegram, Users.LinkToVk\n" +
                "from Users\n" +
                "inner join University on University.UniversityID = Users.UniversityID\n" +
                "inner join District on District.DistrictID = Users.DistrictID", _db.Connection);
            SqlDataReader reader = await command.ExecuteReaderAsync();
            var i = 0;
            if (reader.HasRows)
                while (await reader.ReadAsync())
                {
                    array[i] = new Cohabitation()
                    {
                        Id = (long) reader.GetValue(0),
                        Age = (int) reader.GetValue(3),
                        Pay = (int) reader.GetValue(4),
                        Course = (int) reader.GetValue(5),
                        FIO = reader.GetValue(1).ToString(),
                        Phone = reader.GetValue(6).ToString(),
                        Email = reader.GetValue(7).ToString(),
                        District = reader.GetValue(8).ToString(),
                        Password = reader.GetValue(11).ToString(),
                        University = reader.GetValue(2).ToString(),
                        Gender = Convert.ToChar(reader.GetValue(9)),
                        Description = reader.GetValue(10).ToString(),
                        LinkToTelegram = reader.GetValue(12).ToString(),
                        LinkToVk = reader.GetValue(13).ToString()
                    };
                    i++;
                }

            await reader.CloseAsync();
            return array;
        }

        // Подсчет кол-ва пользователей
        private async Task<int> GetCountCohabition ()
        {
            SqlCommand commandCount = new("select count(UsersID) from Users", _db.Connection);
            SqlDataReader readerForCount = await commandCount.ExecuteReaderAsync();
            var c = 0;
            if (readerForCount.HasRows && await readerForCount.ReadAsync())
                c = (int) readerForCount.GetValue(0);


            await readerForCount.CloseAsync();
            return c;
        }
    }
}
