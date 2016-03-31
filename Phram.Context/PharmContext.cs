using Pharm.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phram.Context
{
    public class PharmContext : DbContext
    {
        public PharmContext()
            : base("dbConnection")
        {
            //Database.Log = s => Debug.WriteLine(s);
        }
        public DbSet<State> States { get; set; }
        public DbSet<LGA> LGAs { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<HealthFacility> HealthFacilies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<HFManager> HFManagers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
