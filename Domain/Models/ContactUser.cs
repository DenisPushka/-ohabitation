using System;

namespace Domain.Models
{
    /// <summary>
    /// Контактная информация пользователя.
    /// </summary>
    public class ContactUser
    {
        /// <summary>
        /// Id.
        /// </summary>
        public Guid ContactId { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime DateBirthday { get; set; }
        
        /// <summary>
        /// Дата рождения в строковом представлении для принятия даты из JSON.
        /// </summary>
        public string DateBirthdayString { get; set; }

        /// <summary>
        /// Фото.
        /// </summary>
        public byte[] Photo { get; set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Почта.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Курс.
        /// </summary>
        public int Course { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        public char Gender { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Id города.
        /// </summary>
        public Guid CityId { get; set; }
        
        /// <summary>
        /// Город.
        /// </summary>
        public City City { get; set; }
        
        /// <summary>
        /// Id университета.
        /// </summary>
        public Guid UniversityId { get; set; }
        
        /// <summary>
        /// Университет.
        /// </summary>
        public University University { get; set; }

        /// <summary>
        /// Id района.
        /// </summary>
        public Guid DistrictId { get; set; }
        
        /// <summary>
        /// Район.
        /// </summary>
        public District District { get; set; }

        /// <summary>
        /// Ссылка на тг.
        /// </summary>
        public string LinkTelegram { get; set; }

        /// <summary>
        /// Ссылка на вк.
        /// </summary>
        public string LinkVk { get; set; }
    }
}