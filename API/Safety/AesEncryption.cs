using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Сohabitation
{
    /// <summary>
    /// Шифровальщик.
    /// </summary>
    public static class AesEncryption
    {
        /// <summary>
        /// Расшифровывает зашифрованный текст.
        /// </summary>
        /// <param name="cipherText">Зашифрованные текст (Передается с JS (crypto-js).</param>
        /// <param name="securityKeyAndIv">Секретный ключ и вектор ицициализации для шифрования.</param>
        /// <returns>Расшифрованные данные, в виде строки.</returns>
        public static string DecryptStringAes(string cipherText, string securityKeyAndIv)
        {
            var keynotes = Encoding.UTF8.GetBytes(securityKeyAndIv);
            var iv = Encoding.UTF8.GetBytes(securityKeyAndIv);

            var encrypted = Convert.FromBase64String(cipherText);
            var decryptedFromJs = DecryptStringFromBytes(encrypted, keynotes, iv);
            return string.Format(decryptedFromJs);
        }

        /// <summary>
        /// Расшифровывает массив байт, полученный из зашифрованной строки.
        /// </summary>
        /// <param name="cipherText">Массив байт.</param>
        /// <param name="key">Секретный ключ для алгоритма симметричного шифрования.</param>
        /// <param name="iv">Вектор инициализации для алгоритма симметричного шифрования.</param>
        /// <returns>Расшифрованная строка.</returns>
        /// <exception cref="ArgumentNullException"/>
        private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (cipherText is not { Length: > 0 })
            {
                throw new ArgumentNullException(nameof(cipherText));
            }

            if (key is not { Length: > 0 })
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (iv is not { Length: > 0 })
            {
                throw new ArgumentNullException(nameof(key));
            }

            // Declare the string used to hold
            // the decrypted text.
            string plaintext;

            // Create an RijndaelManaged object
            // with the specified key and IV.
            using var rijAlg = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                FeedbackSize = 128,
                Key = key,
                IV = iv
            };

            // Create a decrytor to perform the stream transform.
            var decrypt = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

            try
            {
                // Create the streams used for decryption.
                using var msDecrypt = new MemoryStream(cipherText);
                using var csDecrypt = new CryptoStream(msDecrypt, decrypt, CryptoStreamMode.Read);
                using var srDecrypt = new StreamReader(csDecrypt);
                // Read the decrypted bytes from the decrypting stream
                // and place them in a string.
                plaintext = srDecrypt.ReadToEndAsync().Result;
            }
            catch
            {
                plaintext = "keyError";
            }

            return plaintext;
        }

        /// <summary>
        /// Шифровальщик. Преобразует обычную строку в зашифрованный массив байт.
        /// </summary>
        /// <param name="plainText">Строка для шифрования.</param>
        /// <param name="key">Секретный ключ для алгоритма симметричного шифрования.</param>
        /// <param name="iv">Вектор инициализации для алгоритма симметричного шифрования.</param>
        /// <returns>Зашифрованный массив байт.</returns>
        /// <exception cref="ArgumentNullException"/>
        public static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (plainText is not { Length: > 0 })
            {
                throw new ArgumentNullException(nameof(plainText));
            }

            if (key is not { Length: > 0 })
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (iv is not { Length: > 0 })
            {
                throw new ArgumentNullException(nameof(key));
            }

            byte[] encrypted;
            // Create a RijndaelManaged object
            // with the specified key and IV.
            using var rijAlg = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                FeedbackSize = 128,
                Padding = PaddingMode.PKCS7,
                Key = key,
                IV = iv
            };

            // Create a decrytor to perform the stream transform.
            var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

            // Create the streams used for encryption.
            using var msEncrypt = new MemoryStream();
            using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using (var swEncrypt = new StreamWriter(csEncrypt))
            {
                //Write all data to the stream.
                swEncrypt.WriteAsync(plainText);
            }

            encrypted = msEncrypt.ToArray();

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }
    }
}