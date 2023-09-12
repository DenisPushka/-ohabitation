using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Сohabitation
{
    /// <summary>
    /// Хешировальщик.
    /// </summary>
    public static class HashHelper
    {
        /// <summary>
        /// Вычисление MD5 хэша.
        /// </summary>
        /// <param name="text">Строка из которой вычисляется хеш.</param>
        /// <returns>Хэш.</returns>
        public static string GetHash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(text));
            return hash.Aggregate("", (current, b) => current + b.ToString("x2"));
        }
    }
}