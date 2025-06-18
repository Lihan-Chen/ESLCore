using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class ClearanceTypeEntityTypeConfiguration : IEntityTypeConfiguration<ClearanceType>
    {
        public void Configure(EntityTypeBuilder<ClearanceType> builder)
        {
            builder.HasKey(e => e.ClearanceTypeNo).HasName("ESL_CLEARANCETYPES_PK");

            builder.ToTable("ESL_CLEARANCETYPES");

            builder.Property(e => e.ClearanceTypeNo)
                .HasColumnName("CLEARANCETYPENO").HasColumnType("NUMBER").HasPrecision(2);

            builder.Property(e => e.ClearanceTypeAbbr)
                .HasColumnName("CLEARANCETYPEABBR").HasColumnType("VARCHAR2").HasMaxLength(5).IsUnicode(false);

            builder.Property(e => e.ClearanceTypeName)
                .HasColumnName("CLEARANCETYPENAME").HasColumnType("VARCHAR2").HasMaxLength(40).IsUnicode(false);
                
            builder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(400).IsUnicode(false);

            builder.Property(e => e.SortNo)
                .HasColumnName("SORTNO").HasColumnType("NUMBER").HasPrecision(2);

            builder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            builder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);
        }
    }
}
