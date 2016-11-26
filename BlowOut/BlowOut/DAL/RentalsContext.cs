using BlowOut.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlowOut.DAL
{
    public class RentalsContext : DbContext
    {

        public RentalsContext() : base("ClientInstrumentsContext")
        {

        }

        public DbSet<Client> client { get; set; }
        public DbSet<Instrument> instrument { get; set; }



    }
}