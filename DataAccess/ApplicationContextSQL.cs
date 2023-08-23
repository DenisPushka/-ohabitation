using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    /// <summary>
    /// Запросник в базу данных.
    /// </summary>
    public class ApplicationContextSql
    {
        /// <summary>
        /// Строка подключения.
        /// </summary>
        private readonly string _connection;

        /// <summary>
        /// Конструктор, принимающий источник конфигурации.
        /// </summary>
        /// <param name="config">Источник конфигурации.</param>
        public ApplicationContextSql(IConfiguration config)
        {
            _connection = config.GetConnectionString("ConnectionStringToDbCohabitation");
        }

        /// <summary>
        /// Получение всех пользователей.
        /// </summary>
        /// <returns>Массив пользовтелей.</returns>
        public async Task<User[]> GetUsers()
        {
            await using var connection = new SqlConnection(_connection);
            var users = new List<User>();

            try
            {
                await connection.OpenAsync();

                var command = new SqlCommand(
                    "SELECT " +
                    "u.MinMoney" +
                    ", u.MaxMoney" +
                    ", cu.Name" +
                    ", cu.Lastname" +
                    ", cu.Patronymic" +
                    ", cu.DateBirthday" +
                    ", cu.Phone" +
                    ", cu.Email" +
                    ", cu.Photo" +
                    ", cu.Age" +
                    ", cu.Course" +
                    ", cu.Gender" +
                    ", c.Name" +
                    ", d.Name " +
                    ", un.Name " +
                    ", cu.LinkVk" +
                    ", cu.LinkTelegram " +
                    "FROM [dbo].[User] u" +
                    "   INNER JOIN [dbo].[ContactUser] cu" +
                    "       ON u.ContactUserId = cu.ContactUserId" +
                    "   LEFT JOIN [dbo].[City] c" +
                    "       ON cu.CityId = c.CityId" +
                    "   LEFT JOIN [dbo].[District] d" +
                    "       ON cu.DistrictId = d.DistrictId" +
                    "   LEFT JOIN [dbo].[University] un" +
                    "       ON cu.UniversityId = un.UniversityId", connection);

                await using var reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (reader.ReadAsync().Result)
                    {
                        users.Add(new User
                        {
                            MinMoney = (double)Convert.ToDecimal(reader[0]),
                            MaxMoney = (double)Convert.ToDecimal(reader[1]),
                            ContactUser = new ContactUser
                            {
                                Name = (string)reader[2],
                                Lastname = (string)reader[3],
                                Patronymic = (string)reader[4],
                                DateBirthday = (DateTime)reader[5],
                                Phone = (string)reader[6],
                                Email = (string)reader[7],
                                Photo = (byte[])reader[8],
                                Age = (int)reader[9],
                                Course = (int)reader[10],
                                Gender = Convert.ToChar(Convert.ToString(reader[11])!),
                                City = new City { Name = (string)reader[12] },
                                District = new District { Name = (string)reader[13] },
                                University = new University { Name = (string)reader[14] },
                                LinkVk = (string)reader[15],
                                LinkTelegram = (string)reader[16]
                            }
                        });
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            return users.ToArray();
        }
    }
}