using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class UnitEntityTypeConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> unitBuilder)
        {
            // Table
            unitBuilder.ToTable("ESL_UNITS");

            // Primary key
            unitBuilder.HasNoKey();

            // Indexes

            // Properties
            unitBuilder.Property(e => e.UnitNo)
                .HasColumnName("UNITNO").HasColumnType("NUMBER").HasPrecision(2);

            unitBuilder.Property(e => e.UnitName)
                .HasColumnName("UNITNAME").HasColumnType("VARCHAR2").HasMaxLength(20).IsUnicode(false);

            unitBuilder.Property(e => e.UnitDesc)
                .HasColumnName("UNITDESC").HasColumnType("VARCHAR2").HasMaxLength(200).IsUnicode(false);

            unitBuilder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(200).IsUnicode(false);

            unitBuilder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            unitBuilder.Property(e => e.UpdateBy)
                .HasColumnName("UPDATEBY").HasColumnType("VARCHAR2").HasMaxLength(80).IsUnicode(false);
        }
    }
}
