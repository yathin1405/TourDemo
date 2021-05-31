using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TourDemo.Models
{
    public class UserTour : AdminTour
    {
        TourContext db = new TourContext();
        [Key]
        [Display(Name = "User ID")]
        public int UserID { get; set; }

        [Display(Name = "Number of Guests")]
        public int Num_Guests { get; set; }
        public double Discount { get; set; }
        public virtual AdminTour From { get; set; }
        public virtual AdminTour To { get; set; }

        public double disct()
        {

            double discount = 0;
            if (Num_Guests <= 2)
            {
                discount = Price * 0.15;
            }
            else
               if (Num_Guests > 2 && Num_Guests <= 4)
            {
                discount = Price * 0.20;
            }
            else
                if (Num_Guests > 4 && Num_Guests <= 6)
            {
                discount = Price * 0.25;
            }
            else
                 if (Num_Guests > 6 && Num_Guests <= 8)
            {
                discount = Price * 0.30;
            }
            else
                if (Num_Guests > 8 && Num_Guests <= 10)
            {
                discount = Price * 0.40;
            }
            return discount;
            
            
            }
        public string GetTourNum()
        {

            var LocationFrom= (from x in db.AdminTours
                               where x.Tour_Num == Tour_Num
                             select x.LocationFrom).Single();


            return LocationFrom .ToString();


        }

        public string GetDepart()
        {
            var TourName = (from x in db.AdminTours
                          where x.Tour_Num == Tour_Num
                          select x.TourName).Single();

            return TourName.ToString();
        }
    }
    }
