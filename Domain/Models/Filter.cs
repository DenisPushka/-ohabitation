namespace Domain.Models
{
    /// <summary>
    /// Фильтр для поиска пользователей.
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// По полу.
        /// </summary>
        public char Gender { get; set; }

        /// <summary>
        /// Ценовой диапозон.
        /// </summary>
        public int Pay { get; set; }

        /// <summary>
        /// Университет.
        /// </summary>
        public University University { get; set; }

        /// <summary>
        /// Курс.
        /// </summary>
        public char Course { get; set; }

        /// <summary>
        /// Город.
        /// </summary>
        public City City { get; set; }

        /// <summary>
        /// Район.
        /// </summary>
        public District District { get; set; }
    }
}