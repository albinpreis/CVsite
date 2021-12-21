using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data
{
    public class CvContext : DbContext
    {
        public CvContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<Cv> Cvs { get; set; }
    }
}
