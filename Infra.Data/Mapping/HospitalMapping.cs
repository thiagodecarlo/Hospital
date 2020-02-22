using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    class HospitalMapping : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.Property(e => e.Id).IsUnicode(false).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Name).IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.Address).IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.CNPJ).IsUnicode(false).HasMaxLength(14);
        }
    }
}
