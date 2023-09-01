using System;
using System.Text.RegularExpressions;
using Domain.Models;

namespace ValidationHelper
{
    /// <summary>
    /// Помощник в проверке данных.
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// Проверка <paramref name="id"/> на Guid.Empty.
        /// </summary>
        /// <param name="id">Проверяемый id.</param>
        /// <exception cref="ArgumentException"/>
        public static void CheckGuid(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException($"Передан пустой Guid id {id}");
            }
        }
        
        /// <summary>
        /// Проверка строки на null и на содержимое.
        /// </summary>
        /// <param name="text">Проверяемая строка.</param>
        public static void CheckString(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrEmpty(text))
            {
                throw new ArgumentException($"Строка - {text}, пуста!");
            }
        }

        /// <summary>
        /// Проверка строки на наличие даты.
        /// </summary>
        /// <param name="date">Проверяемая строка с предполагаемой датой.</param>
        /// <exception cref="ArgumentException"/>
        public static void CheckDateFromUser(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                throw new ArgumentException($"Передана пустая строка для даты {date}");
            }

            var regex = new Regex("\\..*\\..*-.*-.*/.*/", RegexOptions.IgnoreCase);
            var arrayDate = regex.Split(date);

            foreach (var number in arrayDate)
            {
                if (!int.TryParse(number, out _))
                {
                    throw new ArgumentException($"Передано не число!{number}");
                }
            }
        }

        /// <summary>
        /// Проверка всех полей пользователя.
        /// </summary>
        /// <param name="user">Проверяемый пользователь.</param>
        public static void CheckUserForAllField(User user)
        {
            if (user?.ContactUser == null 
                || string.IsNullOrWhiteSpace(user.Login)
                || string.IsNullOrWhiteSpace(user.Password)
                || string.IsNullOrWhiteSpace(user.ContactUser.Name) 
                || string.IsNullOrWhiteSpace(user.ContactUser.Lastname) 
                || string.IsNullOrWhiteSpace(user.ContactUser.Patronymic) 
                || string.IsNullOrWhiteSpace(user.ContactUser.Email) 
                || string.IsNullOrWhiteSpace(user.ContactUser.Phone) 
                || user.ContactUser.Description == null 
                || string.IsNullOrWhiteSpace(user.ContactUser.City.Name))
            {
                throw new ArgumentException($"Некорректно введен аргумент {user?.ContactUser}");
            }
            
            CheckDateFromUser(user.ContactUser.DateBirthdayString);
        }
    }
}