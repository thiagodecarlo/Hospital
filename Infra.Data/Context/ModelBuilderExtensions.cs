using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hospital>().HasData(
              new Hospital()
              {
                  Id = 1,
                  Name = "Hospital das Clínicas",
                  CNPJ = "00111222333123455",
                  Address = "Av Brasil, 1000"
              }
          );
        }
    }
}