namespace DataAccess.Models
{
    /// <summary>
    /// Аутентификации пользователя.
    /// </summary>
    public class UserAuthentification
    {
        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }
    }
}