using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class ApplicationUserProject
    {
        [Key, ForeignKey("ApplicationUser")]
        [Column(Order =0)]
        public string ApplicationUserId { get; set; }   

        public virtual ApplicationUser ApplicationUser { get; set; }
        
        [Key, ForeignKey("Project")]
        [Column(Order =1)]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
