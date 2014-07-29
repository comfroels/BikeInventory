using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace BikeInventory.Models
{
    public class Bike
    {
        public int ID { get; set; }
        public string name { get; set; }
        [Range(1,10)]
        public int rating { get; set; }

        [DataType(DataType.Currency)]
        public decimal price { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }

    }


    public class BikeDBContext : DbContext
    {
        public DbSet<Bike> Bikes { get; set; }
    }

}