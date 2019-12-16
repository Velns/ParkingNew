using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.Models
{
    class TalonContext : DbContext
    {
        public TalonContext()
            : base("DbConnection")
        { }

        public DbSet<Talon> Talons { get; set; }
    }
}
