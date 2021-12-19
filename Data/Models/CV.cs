using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CV
    {
        public int ID { get; set; }
        public virtual User User { get; set; }
        public string Competence { get; set; }
    }
}
