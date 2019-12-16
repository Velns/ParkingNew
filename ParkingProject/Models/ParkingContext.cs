using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.Models
{
    class ParkingContext : DbContext
    {
        public ParkingContext()
            : base("DbConnection")
        { }

        public DbSet<Parking> Parkings { get; set; }
    }
}
