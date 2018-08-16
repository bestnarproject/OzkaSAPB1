using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace adminlte.Models
{
  public class DatabaseContext : DbContext
  {
    public DatabaseContext() : base("DBConnection")
    {

    }
    public DbSet<Kalemler> Kalemler { get; set; }
  }
}