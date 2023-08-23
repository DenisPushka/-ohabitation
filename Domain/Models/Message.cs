using System;

namespace Domain.Models
{
    /// <summary>
    /// Сообщение.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Id.
        /// </summary>
        public Guid MessageId { get; set; }

        /// <summary>
        /// Id пользователя.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Id чата.
        /// </summary>
        public Guid ChatId { get; set; }

        /// <summary>
        /// Чат.
        /// </summary>
        public Chat Chat { get; set; }

        /// <summary>
        /// Само сообщение.
        /// </summary>
        public string Description { get; set; }
    }
}