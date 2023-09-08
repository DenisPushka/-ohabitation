using System;

namespace Сohabitation
{
    /// <summary>
    /// Ip детали запроса, для учета количества запросов с 1 IP адресса.
    /// </summary>
    public class IpDetailModel
    {
        /// <summary>
        /// Ip адресс.
        /// </summary>
        public string IpAddress {
            get;
            set;
        }
        
        /// <summary>
        /// Время запроса. 
        /// </summary>
        public DateTime Time {
            get;
            set;
        }
        
        /// <summary>
        /// Количество сделанных запросов.
        /// </summary>
        public int Count {
            get;
            set;
        }
    }
}