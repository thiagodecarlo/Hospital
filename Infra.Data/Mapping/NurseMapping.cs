using Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    class NurseMapping : IEntityTypeConfiguration<Nurse>
    {
        public void Configure(EntityTypeBuilder<Nurse> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsUnicode(false).HasMaxLength(100).IsRequired();
            builder.Property(e => e.CPF).IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.COREN).IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.BirthDate).HasColumnType("timestamp").IsRequired(false);
            builder.HasOne(e => e.Hospital);
        }
    }
}
