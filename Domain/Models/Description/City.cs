using System;

namespace Domain.Models
{
    /// <summary>
    /// Город.
    /// </summary>
    public class City
    {
        /// <summary>
        /// Id.
        /// </summary>
        public Guid CityId { get; set; }
        
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
    }
}