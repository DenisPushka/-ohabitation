using System;
using System.Threading.Tasks;
using DataAccess.Interface;
using DataAccess.Models;
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
        /// <param name="newUser">Добавляемый пользователь.</param>
        /// <returns>Массив всех пользователей.</returns>
        public Task<User[]> AddUser(User newUser)
        {
            // TODO validation.
            return _db.AddUser(newUser);
        }

        /// <summary>
        /// Обновление пользователя.
        /// </summary>
        /// <param name="newUser">Измененный пользователь.</param>
        /// <returns><see langword="true" /> - в случае успеха.</returns>
        public Task<bool> UpdateUser(User newUser)
        {
            // TODO validation.
            return _db.UpdateUser(newUser);
        }
        
        /// <summary>
        /// Получение пользователя по <paramref name="guid"/>.
        /// </summary>
        /// <param name="guid">Id искомого пользователя.</param>
        /// <returns>Искомый пользователь.</returns>
        public Task<User> GetUser(Guid guid)
        {
            // TODO validation.
            return _db.GetUser(guid);
        }

        public Task<User> GetUser(UserAuthentification user)
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