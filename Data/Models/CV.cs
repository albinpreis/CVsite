using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class CV
    {
        [Key]
        public int Id { get; set; }
        public string Competence { get; set; }
        public virtual ApplicationUser User { get; set; }
        
    }
}
