using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Cohabitation : Entity
    {
        public string FIO { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Pay { get; set; }
        public int Age { get; set; }
        public int Course { get; set; }
        public char Gender { get; set; }
        public string Description { get; set; }
        public string University { get; set; }
        public string District { get; set; }
    }
}
