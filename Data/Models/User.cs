using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string UserName  { get; set; }
        public string Password { get; set; }
        public string ImagePath { get; set; }
        public string Address { get; set; }
        public bool PrivateUser { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public virtual ICollection<CV> Cvs { get; set; }

    }
}
