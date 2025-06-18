using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class PlantShiftEntityTypeConfiguration : IEntityTypeConfiguration<PlantShift>
    {
        public void Configure(EntityTypeBuilder<PlantShift> plantShiftBuilder)
        {
            // Table
            plantShiftBuilder.ToTable("ESL_PLANTSHIFTS");

            // Primary key
            plantShiftBuilder.HasKey(e => new { e.FacilNo, e.ShiftNo }).HasName("PLANTSHIFT_PK");

            // Indexes
            plantShiftBuilder.HasIndex(e => new { e.FacilNo, e.ShiftNo, e.ShiftStart, e.ShiftEnd }, "ESL_PLANTSHIFTS_UNQ").IsUnique();

            // Properties
            plantShiftBuilder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasColumnType("NUMBER").HasPrecision(2); 

            plantShiftBuilder.Property(e => e.ShiftNo)
                .HasColumnName("SHIFTNO").HasColumnType("NUMBER").HasPrecision(2);
                
            plantShiftBuilder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(400).IsUnicode(false);

            plantShiftBuilder.Property(e => e.ShiftEnd)
                .HasColumnName("SHIFTEND").HasColumnType("VARCHAR2").HasMaxLength(5).IsUnicode(false);

            plantShiftBuilder.Property(e => e.ShiftName)
                .HasColumnName("SHIFTNAME").HasColumnType("VARCHAR2").HasMaxLength(20).IsUnicode(false);

            plantShiftBuilder.Property(e => e.ShiftStart)
                .HasColumnName("SHIFTSTART").HasColumnType("VARCHAR2").IsUnicode(false).HasMaxLength(5);

            plantShiftBuilder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            plantShiftBuilder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);
        }
    }
}
