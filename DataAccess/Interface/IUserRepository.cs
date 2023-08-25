using System;
using System.Threading.Tasks;
using DataAccess.Models;
using Domain.Models;

namespace DataAccess.Interface
{
    /// <summary>
    /// Интерфейс репозитория пользователя.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Добавление пользователя.
        /// </summary>
        /// <param name="user">Добавляемый пользователь.</param>
        /// <returns></returns>
        Task<User[]> AddUser(User user);

        /// <summary>
        /// Обновление пользователя.
        /// </summary>
        /// <param name="newUser">Измененный пользователь.</param>
        /// <returns><see langword="true" /> - в случае успеха.</returns>
        public Task<bool> UpdateUser(User newUser);

        /// <summary>
        /// Поиск пользователей с фильтром.
        /// </summary>
        /// <param name="filter">Параметры фильтрации поиска.</param>
        /// <returns>Пользователи по определенному фильтру.</returns>
        //Task<User[]> GetUserOnFilter(Filter filter);

        /// <summary>
        /// Получение пользователя по <paramref name="guid"/>.
        /// </summary>
        /// <param name="guid">Id искомого пользователя.</param>
        /// <returns>Искомый пользователь.</returns>
        public Task<User> GetUser(Guid guid);

        /// <summary>
        /// Получение пользователя.
        /// </summary>
        /// <param name="user">По аунтефикации.</param>
        /// <returns>Искомый пользователь.</returns>
        public Task<User> GetUser(UserAuthentification user);

        /// <summary>
        /// Получение всех пользователей.
        /// </summary>
        /// <returns>Массив пользователей.</returns>
        Task<User[]> GetUsers();
    }
}