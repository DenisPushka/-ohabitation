using System;
using System.Threading.Tasks;
using DataAccess.Interface;
using DataAccess.Models.DTO;
using Domain.Models;

namespace DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий пользователя.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Исполнитель запросов.
        /// </summary>
        private readonly ApplicationContextSql _db;

        public UserRepository(ApplicationContextSql db) => _db = db;

        /// <summary>
        /// Добавление пользователя.
        /// </summary>
        /// <param name="user">Добавляемый пользователь.</param>
        /// <returns>Массив всех пользователей.</returns>
        public Task<User[]> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Обновление пользователя.
        /// </summary>
        /// <param name="newUser">Измененный пользователь.</param>
        /// <returns>true - в случае успеха.</returns>
        public bool UpdateUser(User newUser)
        {
            throw new NotImplementedException();
        }

        public User GetUser(Guid guid)
        {
            throw new NotImplementedException();
        }

        public User GetUser(UserAuthentification user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Получение всех пользователей.
        /// </summary>
        /// <returns>Массив пользователей</returns>
        public async Task<User[]> GetUsers() => await _db.GetUsers();
    }
}