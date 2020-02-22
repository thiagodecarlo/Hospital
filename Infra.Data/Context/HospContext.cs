using Domain.Entities;
using Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infra.Data.Context
{
    public class HospContext : DbContext
    {
        public HospContext(DbContextOptions<HospContext> options) :
            base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HospitalMapping());
            modelBuilder.ApplyConfiguration(new NurseMapping());
        }

        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<Nurse> Nurse { get; set; }


        public static DateTime ServerTime()
        {
            DateTime dateTime = DateTime.UtcNow;
            TimeZoneInfo serverHour = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, serverHour);
        }
    }
}
