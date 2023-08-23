using System;

namespace Domain.Models
{
    /// <summary>
    /// Район.
    /// </summary>
    public class District
    {
        /// <summary>
        /// Id.
        /// </summary>
        public Guid DistrictId { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
    }
}