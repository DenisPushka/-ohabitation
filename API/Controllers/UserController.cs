using System;
using System.Threading.Tasks;
using DataAccess.Interface;
using DataAccess.Models;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        /// Источник конфигурации.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Репозиторий пользователя.
        /// </summary>
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
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
            var newUser = new UserAuthentification
            {
                Login = AesEncryption.DecryptStringAes(user.Login, _configuration["SecurityKey"]),
                Password = HashHelper.GetHash(user.Password)
            };

            return newUser.Login.Equals("keyError")
                ? Ok(new User())
                : Ok(await _userRepository.Authorization(newUser));
        }

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