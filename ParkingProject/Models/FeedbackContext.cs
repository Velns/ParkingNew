using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.Models
{
    class FeedbackContext : DbContext
    {
        public FeedbackContext()
            : base("DbConnection")
        { }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}