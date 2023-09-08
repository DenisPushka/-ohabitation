using System;
using System.Threading.Tasks;
using DataAccess.Interface;
using DataAccess.Models;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Сohabitation;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер для работы с пользователем.
    /// </summary>
    [ApiController, Route("api/[controller]")]
    [ServiceFilter(typeof(TraceIpAttribute))]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Репозиторий пользователя.
        /// </summary>
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) => _userRepository = userRepository;

        /// <summary>
        /// Добавление пользователя.
        /// </summary>
        /// <param name="newUser">Добавляемый пользователь.</param>
        /// <returns>Массив всех пользователей.</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> AddPerson([FromForm] User newUser)
        {
            ValidationHelper.ValidationHelper.CheckDateFromUser(newUser.ContactUser.DateBirthdayString);
            
            newUser.ContactUser.DateBirthday = Convert.ToDateTime(newUser.ContactUser.DateBirthdayString);
            return Ok(await _userRepository.AddUser(newUser));
        }

        /// <summary>
        /// Проверка пользователя в системе.
        /// </summary>
        /// <param name="user">Проверяемый пользователь.</param>
        /// <returns>Если пользователь найден - он и возвращается,
        /// если не найден - будет возвращен пустой пользователь.</returns>
        [HttpPost("Authorization")]
        public async Task<IActionResult> Authorization([FromForm] UserAuthentification user)
        {
            return Ok(await _userRepository.Authorization(user));
        }

        /// <summary>
        /// Получение пользователей системы.
        /// </summary>
        /// <returns>Массив пользователей.</returns>
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userRepository.GetUsers());
        }

        /// <summary>
        /// Получение пользователя по <paramref name="id"/>.
        /// </summary>
        /// <param name="id">Id искомого пользователя.</param>
        /// <returns>Искомый пользователь.</returns>
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            ValidationHelper.ValidationHelper.CheckGuid(id);

            return Ok(await _userRepository.GetUser(id));
        }
    }
}