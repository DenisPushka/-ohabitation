using System;

namespace Domain.Models
{
    /// <summary>
    /// Университет.
    /// </summary>
    public class University
    {
        /// <summary>
        /// Id.
        /// </summary>
        public Guid UniversityId { get; set; }
        
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
    }
}
