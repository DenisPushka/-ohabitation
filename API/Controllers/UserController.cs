using System.Threading.Tasks;
using DataAccess.Interface;
using DataAccess.Models.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Контроллер для работы с пользователем.
    /// </summary>
    [ApiController, Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Репозиторий пользователя.
        /// </summary>
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) => _userRepository = userRepository;

        /// <summary>
        /// Добавления пользователя.
        /// </summary>
        /// <param name="user">Добавляемый пользователь.</param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<IActionResult> AddPerson([FromBody] User user)
        {
            // Todo add validation.
            return Ok(await _userRepository.AddUser(user));
        }

        [HttpPost("Authorization")]
        public async Task<IActionResult> Authorization([FromBody] UserAuthentification userAuthentification) => Ok();
        
        /// <summary>
        /// Получение пользователей системы.
        /// </summary>
        /// <returns>Массив пользователей.</returns>
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetUsers() => Ok(await _userRepository.GetUsers());
    }
}
