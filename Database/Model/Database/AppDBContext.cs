using Database.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Model.Database
{
    public  class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
             : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
             => optionsBuilder.UseSqlite("Data Source=DakarRallyDatabase.db");
          
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Race> Race { get; set; }
        public DbSet<VehicleRace> VehicleRace { get; set; }
       

    }
}
