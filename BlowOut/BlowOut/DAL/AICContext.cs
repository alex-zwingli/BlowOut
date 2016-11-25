using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AwesomeInstrumentCompany.Models;
using System.Data.Entity;

namespace AwesomeInstrumentCompany.DAL
{
    public class AICContext : DbContext 
    {
        public AICContext () : base("AICContext")
        {

        }

        //Data structure that stores data
        public DbSet<Client> Clients { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
    }
}