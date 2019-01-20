using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaFalabella.Models
{
    public class FalabellaContext : DbContext
    {
        public FalabellaContext() : base("PruebaFalabellaContext") { }

        public DbSet<Compania> Compania { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Asesor> Asesor { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

    }
}