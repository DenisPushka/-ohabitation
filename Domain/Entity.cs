using System;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Domain
{
    /// Базовый класс всех DDD сущностей.
    /// </summary>
    /// <typeparam name="TId">Тип идентификатора</typeparam>
    public class Entity
    {
        [Key]
        public long Id { get; set; }
    }
}
