using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.Models
{
    public class PlaceContext : DbContext
    {
        public PlaceContext()
            : base("DbConnection")
        { }

        public DbSet<Place> Places { get; set; }
    }
}
