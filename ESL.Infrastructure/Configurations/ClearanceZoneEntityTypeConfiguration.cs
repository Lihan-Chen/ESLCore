using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class ClearanceZoneEntityTypeConfiguration : IEntityTypeConfiguration<ClearanceZone>
    {
        public void Configure(EntityTypeBuilder<ClearanceZone> builder)
        {
            // Table
            builder.ToTable("ESL_CLEARANCEZONES");

            // Primary Keys
            builder.HasKey(e => new { e.FacilType, e.ZoneNo }).HasName("ESL_CLEARANCEZONES_PK");

            // Properties
            builder.Property(e => e.FacilType)
                .HasColumnName("FACILTYPE").HasColumnType("VARCHAR2").HasMaxLength(5).IsUnicode(false);

            builder.Property(e => e.ZoneNo)
                .HasColumnName("ZONENO").HasColumnType("NUMBER").HasPrecision(3);
            
            builder.Property(e => e.ZoneDescription)
                .HasColumnName("ZONEDESCRIPTION").HasColumnType("VARCHAR2").HasMaxLength(200).IsUnicode(false);

            builder.Property(e => e.Disable)
                .HasColumnName("DISABLE").HasColumnType("VARCHAR2").HasMaxLength(30).IsUnicode(false);

            builder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasColumnType("NUMBER").HasPrecision(2);

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
