using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.Models
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext()
            : base("DbConnection")
        { }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}