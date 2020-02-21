using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    class HospitalMapping : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.Property(e => e.Name).IsUnicode(false).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Description).IsUnicode(false).HasMaxLength(500);
            builder.HasOne(e => e.SubArea).WithMany(e => e.Skills).IsRequired(false);
            builder.Property(e => e.Approved).HasDefaultValue(true);
            builder.Property(e => e.ApprovalDate).HasColumnType("timestamp").IsRequired(false);
            builder.HasOne(e => e.Creator).WithMany(x => x.SkillsCreated).HasForeignKey(x => x.CreatorId);
            builder.HasOne(e => e.ApprovedBy).WithMany(x => x.SkillsApproved).HasForeignKey(x => x.ApprovedById).IsRequired(false);
            builder.Property(e => e.Active).HasDefaultValue(true);
            builder.Property(e => e.RegistryDate).HasColumnType("timestamp");
            builder.Property(e => e.RegistryChange).HasColumnType("timestamp");

        }
    }
}
