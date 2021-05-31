using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TourDemo.Models
{
    public class TourContext:DbContext
    {
        public TourContext() : base("TourDb") { }



        public DbSet<AdminTour> AdminTours{ get; set; }

        public DbSet<UserTour> UserTours { get; set; }


        public static TourContext Create()
        {
            return new TourContext();
        }

        protected override void OnModelCreating(DbModelBuilder ModelBuilder)
        {
            ModelBuilder.Entity< AdminTour> ().HasKey<int>(x => x.Tour_Num);

            ModelBuilder.Entity<UserTour>().HasKey<int>(x => x.UserID);


        }
    }
}