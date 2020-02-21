using Domain.Entities;
using Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace COMPE.Infra.Data.Context
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "DEVELOPMENT")
                {
                    optionsBuilder.UseNpgsql(_published);
                }
                else
                    optionsBuilder.UseNpgsql(_published);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HospitalMapping());
            modelBuilder.ApplyConfiguration(new NurseMapping());

            modelBuilder.Seed();
        }

        public DbSet<Hospital> Address { get; set; }
        public DbSet<Nurse> Area { get; set; }


        public static DateTime ServerTime()
        {
            DateTime dateTime = DateTime.UtcNow;
            TimeZoneInfo serverHour = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, serverHour);
        }
    }
}
