using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class FacilityEntityTypeConfiguration : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> facilityBuilder)
        {
            // Table
            facilityBuilder.HasNoKey()
                .ToTable("ESL_FACILITIES");

            // Primary key
            //facilityBuilder.HasKey(e => e.FacilNo).HasName("FACILITIES_PK");

            // Indexes
            facilityBuilder.HasIndex(e => e.FacilNo, "ESL_FACILITIES_PK1").IsUnique();

            // Properties
            facilityBuilder.Property(e => e.Disable)
                .HasColumnName("DISABLE").HasColumnType("VARCHAR2").HasMaxLength(15).IsUnicode(false);
                
            facilityBuilder.Property(e => e.FacilAbbr)
                .HasColumnName("FACILABBR").HasColumnType("VARCHAR2").HasMaxLength(5).IsUnicode(false);

            facilityBuilder.Property(e => e.FacilFullName)
                .HasColumnName("FACILFULLNAME").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);

            facilityBuilder.Property(e => e.FacilName)
                .HasColumnName("FACILNAME").HasColumnType("VARCHAR2").HasMaxLength(40).IsUnicode(false);

            facilityBuilder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasColumnType("NUMBER").HasPrecision(3);
            
            facilityBuilder.Property(e => e.FacilType)
                .HasColumnName("FACILTYPE").HasColumnType("VARCHAR2").HasMaxLength(30).IsUnicode(false);

            facilityBuilder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(15).IsUnicode(false);

            facilityBuilder.Property(e => e.SortNo)               
                .HasColumnName("SORTNO").HasColumnType("NUMBER").HasPrecision(2);

            facilityBuilder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            facilityBuilder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);

            facilityBuilder.Property(e => e.VisibleTo)
                .HasColumnName("VISIBLETO").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);
        }
    }
}
