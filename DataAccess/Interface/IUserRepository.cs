using System;
using System.Threading.Tasks;
using DataAccess.Models.DTO;
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
        /// Изменение данных у пользователя.
        /// </summary>
        /// <param name="newUser">Измененный пользователь.</param>
        /// <returns>true - в случае успеха.</returns>
        public bool UpdateUser(User newUser);

        /// <summary>
        /// Поиск пользователей с фильтром.
        /// </summary>
        /// <param name="filter">Параметры фильтрации поиска.</param>
        /// <returns>Пользователи по определенному фильтру.</returns>
        //Task<User[]> GetUserOnFilter(Filter filter);

        /// <summary>
        /// Получение пользователя.
        /// </summary>
        /// <param name="guid">По Id.</param>
        /// <returns>Искомый пользователь.</returns>
        public User GetUser(Guid guid);

        /// <summary>
        /// Получение пользователя.
        /// </summary>
        /// <param name="user">По аунтефикации.</param>
        /// <returns>Искомый пользователь.</returns>
        public User GetUser(UserAuthentification user);

        /// <summary>
        /// Получение всех пользователей.
        /// </summary>
        /// <returns>Массив пользователей.</returns>
        Task<User[]> GetUsers();
    }
}