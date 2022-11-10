using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Filter
    {
        public char Gender { get; set; }
        public int Pay { get; set; }
        public University University { get; set; }
        public char Course { get; set; }
        public District District { get; set; }
    }
}
