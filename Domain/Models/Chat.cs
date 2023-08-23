using System;

namespace Domain.Models
{
    /// <summary>
    /// Чат.
    /// </summary>
    public class Chat
    {
        /// <summary>
        /// Id.
        /// </summary>
        public Guid ChatId { get; set; }

        /// <summary>
        /// Id первого пользователя.
        /// </summary>
        public User UserFirstId { get; set; }

        /// <summary>
        /// Первый пользователь.
        /// </summary>
        public User UserFirst { get; set; }

        /// <summary>
        /// Id второго пользователя.
        /// </summary>
        public User UserSecondId { get; set; }

        /// <summary>
        /// Второй пользователь.
        /// </summary>
        public User UserSecond { get; set; }
    }
}