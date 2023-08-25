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
        /// Получение пользователя(ей) со всеми данными.
        /// </summary>
        private const string SelectUser =
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
            ", cu.Description" +
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
            "       ON cu.UniversityId = un.UniversityId";

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

        #region Get

        /// <summary>
        /// Получение всех пользователей.
        /// </summary>
        /// <returns>Массив пользовтелей.</returns>
        public async Task<User[]> GetUsers()
        {
            await using var connection = new SqlConnection(_connection);
            var users = new List<User>();
            var command = new SqlCommand(SelectUser, connection);

            try
            {
                await connection.OpenAsync();

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
                                Description = (string)reader[12],
                                City = new City { Name = (string)reader[13] },
                                District = new District { Name = (string)reader[14] },
                                University = new University { Name = (string)reader[15] },
                                LinkVk = (string)reader[16],
                                LinkTelegram = (string)reader[17]
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

        /// <summary>
        /// Получение пользователя по <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Id искомого пользователя.</param>
        /// <returns>Искомый пользователь.</returns>
        public async Task<User> GetUser(Guid id)
        {
            await using var connection = new SqlConnection(_connection);
            User user = null;

            try
            {
                await connection.OpenAsync();

                var command = new SqlCommand(
                    SelectUser +
                    " WHERE UserId = @id", connection);

                command.Parameters.AddWithValue("@id", id);
                await using var reader = await command.ExecuteReaderAsync();

                if (reader.HasRows && reader.ReadAsync().Result)
                {
                    user = new User
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
                            Description = (string)reader[12],
                            City = new City { Name = (string)reader[13] },
                            District = new District { Name = (string)reader[14] },
                            University = new University { Name = (string)reader[15] },
                            LinkVk = (string)reader[16],
                            LinkTelegram = (string)reader[17]
                        }
                    };
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            return user ?? new User();
        }

        /// <summary>
        /// Получение возраста у пользователя по <paramref name="login"/>.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <returns>Возраст.</returns>
        private async Task<DateTime> GetDateBirthday(string login)
        {
            // TODO validation login.
            await using var connection = new SqlConnection(_connection);
            var dateBirthday = DateTime.Now;

            try
            {
                await connection.OpenAsync();

                var command = new SqlCommand(
                    "SELECT Cu.DateBirthday FROM [dbo].[User] Us " +
                    "   INNER JOIN ContactUser Cu" +
                    "       ON Cu.ContactUserId = Us.ContactUserId " +
                    "WHERE Us.Login = @login", connection);

                command.Parameters.AddWithValue("@login", login);
                await using var reader = await command.ExecuteReaderAsync();

                if (reader.HasRows && reader.ReadAsync().Result)
                {
                    dateBirthday = (DateTime)reader[0];
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            return dateBirthday;
        }

        #endregion

        /// <summary>
        /// Обновление пользователя.
        /// </summary>
        /// <param name="newUser">Измененный пользователь.</param>
        /// <returns><see langword="true" /> - в случае успеха.</returns>
        public async Task<bool> UpdateUser(User newUser)
        {
            // TODO validation all user's fields.

            const string queryStringForUpdate =
                "UPDATE [dbo].[User]" +
                "   SET " +
                "   ,[Password] = @password" +
                "   ,[MinMoney] = @minMoney" +
                "   ,[MaxMoney] = @maxMoney " +
                "WHERE Login = @login " +
                "GO; " +
                "UPDATE [dbo].[ContactUser]" +
                "   SET " +
                "   [Name] = @name " +
                "   ,[Lastname] = @lastname " +
                "   ,[Patronymic] = @patronymic" +
                "   ,[DateBirthday] = @dateBirthday" +
                "   ,[Photo] = @photo" +
                "   ,[Phone] = @phone" +
                // "   ,[Email] = @email" +
                "   ,[Age] = @age" +
                "   ,[Course] = @course" +
                "   ,[Gender] = @gender" +
                "   ,[Description] = @description" +
                "   ,[CityId] = @cityId" +
                "   ,[DistrictId] = @districtId" +
                "   ,[UniversityId] = @universityId" +
                "   ,[LinkTelegram] = @linkTelegram" +
                "   ,[LinkVk] = @linkVk " +
                "WHERE Email = @email";

            await using var connection = new SqlConnection(_connection);
            var command = new SqlCommand(queryStringForUpdate, connection);

            var oldDateBirthday = await GetDateBirthday(newUser.Login);
            var buff = newUser.ContactUser.DateBirthday.Year - oldDateBirthday.Year;
            var newAge = oldDateBirthday.AddYears(buff) <= newUser.ContactUser.DateBirthday
                ? buff
                : buff - 1;

            #region Parameters

            command.Parameters.AddWithValue("@password", newUser.Password);
            command.Parameters.AddWithValue("@minMoney", newUser.MinMoney);
            command.Parameters.AddWithValue("@maxMoney", newUser.MaxMoney);
            command.Parameters.AddWithValue("@name", newUser.ContactUser.Name);
            command.Parameters.AddWithValue("@lastname", newUser.ContactUser.Lastname);
            command.Parameters.AddWithValue("@patronymic", newUser.ContactUser.Patronymic);
            command.Parameters.AddWithValue("@dateBirthday", newUser.ContactUser.DateBirthday);
            command.Parameters.AddWithValue("@photo", newUser.ContactUser.Photo);
            command.Parameters.AddWithValue("@phone", newUser.ContactUser.Phone);
            command.Parameters.AddWithValue("@email", newUser.ContactUser.Email);
            command.Parameters.AddWithValue("@age", newAge);
            command.Parameters.AddWithValue("@course", newUser.ContactUser.Course);
            command.Parameters.AddWithValue("@gender", newUser.ContactUser.Gender);
            command.Parameters.AddWithValue("@description", newUser.ContactUser.Description);
            command.Parameters.AddWithValue("@cityId", newUser.ContactUser.CityId);
            command.Parameters.AddWithValue("@districtId", newUser.ContactUser.DistrictId);
            command.Parameters.AddWithValue("@universityId", newUser.ContactUser.UniversityId);
            command.Parameters.AddWithValue("@linkTelegram", newUser.ContactUser.LinkTelegram);
            command.Parameters.AddWithValue("@linkVk", newUser.ContactUser.LinkVk);

            #endregion

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e);
                throw;
            }

            return true;
        }

        /// <summary>
        /// Добавление пользователя.
        /// </summary>
        /// <param name="newUser">Добавляемый пользователь.</param>
        /// <returns>Массив всех пользователей.</returns>
        public async Task<User[]> AddUser(User newUser)
        {
            // TODO validation all user's fields.
            
            await using var connection = new SqlConnection(_connection);
            await AddContactUser(newUser, connection);
            var contactUserId = await GetContactUserId(connection);
            await AddUser(newUser, connection, contactUserId);

            return await GetUsers();
        }

        /// <summary>
        /// Добавление контакта пользователя.
        /// </summary>
        /// <param name="newUser">Добавляемый пользователь.</param>
        /// <param name="connection">Подключение к БД.</param>
        private async Task AddContactUser(User newUser, SqlConnection connection)
        {
            const string queryAddUserContact =
                "INSERT INTO [dbo].[ContactUser]" +
                "   (" +
                "       [Name]" +
                "       ,[Lastname]" +
                "       ,[Patronymic]" +
                "       ,[DateBirthday]" +
                "       ,[Photo]" +
                "       ,[Phone]" +
                "       ,[Email]" +
                "       ,[Age]" +
                "       ,[Course]" +
                "       ,[Gender]" +
                "       ,[Description]" +
                "       ,[CityId]" +
                "       ,[DistrictId]" +
                "       ,[UniversityId]" +
                "       ,[LinkTelegram] " +
                "       ,[LinkVk]" +
                "   ) " +
                "VALUES" +
                "   (" +
                "       @name " +
                "       ,@lastname " +
                "       ,@patronymic" +
                "       ,@dateBirthday" +
                "       ,@photo" +
                "       ,@phone" +
                "       ,@email" +
                "       ,@age" +
                "       ,@course" +
                "       ,@gender" +
                "       ,@description" +
                "       ,@cityId" +
                "       ,@districtId" +
                "       ,@universityId" +
                "       ,@linkTelegram" +
                "       ,@linkVk" +
                "   )";

            var command = new SqlCommand(queryAddUserContact, connection);

            var oldDateBirthday = newUser.ContactUser.DateBirthday;
            var buff = DateTime.Now.Year - oldDateBirthday.Year;
            var newAge = oldDateBirthday.AddYears(buff) <= DateTime.Now
                ? buff
                : buff - 1;

            #region Parameters

            command.Parameters.AddWithValue("@name", newUser.ContactUser.Name);
            command.Parameters.AddWithValue("@lastname", newUser.ContactUser.Lastname);
            command.Parameters.AddWithValue("@patronymic", newUser.ContactUser.Patronymic);
            command.Parameters.AddWithValue("@dateBirthday", newUser.ContactUser.DateBirthday);
            command.Parameters.AddWithValue("@photo", newUser.ContactUser.Photo);
            command.Parameters.AddWithValue("@phone", newUser.ContactUser.Phone);
            command.Parameters.AddWithValue("@email", newUser.ContactUser.Email);
            command.Parameters.AddWithValue("@age", newAge);
            command.Parameters.AddWithValue("@course", newUser.ContactUser.Course);
            command.Parameters.AddWithValue("@gender", newUser.ContactUser.Gender);
            command.Parameters.AddWithValue("@description", newUser.ContactUser.Description);
            command.Parameters.AddWithValue("@cityId", newUser.ContactUser.CityId);
            command.Parameters.AddWithValue("@districtId", newUser.ContactUser.DistrictId);
            command.Parameters.AddWithValue("@universityId", newUser.ContactUser.UniversityId);
            command.Parameters.AddWithValue("@linkTelegram", newUser.ContactUser.LinkTelegram);
            command.Parameters.AddWithValue("@linkVk", newUser.ContactUser.LinkVk);

            #endregion

            try
            {
                connection.Open();
                await command.ExecuteNonQueryAsync();
                connection.Close();
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Получение ContactUserId добавляемого пользователя.
        /// </summary>
        /// <returns>ContactUserId добавляемого пользователя.</returns>
        private async Task<Guid> GetContactUserId(SqlConnection connection)
        {
            const string querySelectContactUserId =
                "SELECT TOP(1) ContactUserId FROM [dbo].[ContactUser] " +
                "ORDER BY DateCreate DESC";

            var command = new SqlCommand(querySelectContactUserId, connection);
            Guid contactUserId = default;

            try
            {
                connection.Open();
                await using var reader = await command.ExecuteReaderAsync();

                if (reader.HasRows && reader.ReadAsync().Result)
                {
                    contactUserId = (Guid)reader[0];
                }

                connection.Close();
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e);
                throw;
            }

            return contactUserId;
        }

        /// <summary>
        /// Добавление пользователя.
        /// </summary>
        /// <param name="newUser">Добавляемый пользователь.</param>
        /// <param name="connection">Подлючение к БД.</param>
        /// <param name="contactUserId">ContactUserId добавляемого пользователя.</param>
        private async Task AddUser(User newUser, SqlConnection connection, Guid contactUserId)
        {
            const string queryAddUser =
                "INSERT INTO [dbo].[User] " +
                "   (" +
                "       [Login]" +
                "       , [Password]" +
                "       , [MinMoney]" +
                "       , [MaxMoney]" +
                "       , [ContactUserId]" +
                "   ) " +
                "VALUES" +
                "   (" +
                "       @login" +
                "       , @password" +
                "       , @minMoney" +
                "       , @maxMoney" +
                "       , @contactUserId" +
                "   )";
            var command = new SqlCommand(queryAddUser, connection);

            command.Parameters.AddWithValue("@login", newUser.Login);
            command.Parameters.AddWithValue("@password", newUser.Password);
            command.Parameters.AddWithValue("@minMoney", newUser.MinMoney);
            command.Parameters.AddWithValue("@maxMoney", newUser.MaxMoney);
            command.Parameters.AddWithValue("@contactUserId", contactUserId);

            try
            {
                connection.Open();
                await command.ExecuteNonQueryAsync();
            }
            catch (SqlException e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}