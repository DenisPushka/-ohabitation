using System;
using System.Data.SqlTypes;

namespace Domain.Models
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Логин.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Минимальная плата.
        /// </summary>
        public double MinMoney { get; set; }

        /// <summary>
        /// Максимальная плата.
        /// </summary>
        public double MaxMoney { get; set; }
        
        /// <summary>
        /// Контакт Id.
        /// </summary>
        public Guid ContactId { get; set; }
        
        /// <summary>
        /// Контакт пользователя.
        /// </summary>
        public ContactUser ContactUser { get; set; }
    }
}