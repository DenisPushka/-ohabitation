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
        public string Description { get; set; }
        public int Pay { get; set; }
        public char[] Phone { get; set; }
        //public string email { get; set; }
        public University University { get; set; }
        public District District { get; set; }
    }
}
