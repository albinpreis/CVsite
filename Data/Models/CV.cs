using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Cv
    {
        
        [Key, ForeignKey("ApplicationUser")] 
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public string Competence { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        
        
    }
}
