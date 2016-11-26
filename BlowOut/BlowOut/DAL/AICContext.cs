using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlowOut.Models;
using System.Data.Entity;

namespace BlowOut.DAL
{
    public class AICContext : DbContext 
    {
        public AICContext () : base("AICContext")
        {

        }

        //Data structure that stores data
        public DbSet<Client> Clients { get; set; }
        public DbSet<Instrument> Instruments { get; set; }

        public System.Data.Entity.DbSet<BlowOut.Models.Rentals> Rentals { get; set; }
    }
}