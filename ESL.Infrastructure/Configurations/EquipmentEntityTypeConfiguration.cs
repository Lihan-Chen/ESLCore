using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class EquipmentEntityTypeConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> equipmentBuilder)
        {
            // Table
            equipmentBuilder.ToTable("ESL_EQUIPMENTINVOLVED");

            // Primary key
            equipmentBuilder.HasKey(e => new { e.FacilNo, e.EquipNo }).HasName("ESL_EQUIPMENTINVOLVED_PK");

            // Indexes
            equipmentBuilder.HasIndex(e => new { e.FacilNo, e.FacilType, e.EquipName }, "ESL_EQUIPMENTINVOLVED_UNQ").IsUnique();

            // Properties
            equipmentBuilder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasColumnType("NUMBER").HasPrecision(3);
                
            equipmentBuilder.Property(e => e.EquipNo)
                .HasColumnName("EQUIPNO").HasColumnType("NUMBER").HasPrecision(3).ValueGeneratedNever();

            equipmentBuilder.Property(e => e.Disable)
                .HasColumnName("DISABLE").HasColumnType("VARCHAR2").HasMaxLength(30).IsUnicode(false);       

            equipmentBuilder.Property(e => e.EquipName)
                .HasColumnName("EQUIPNAME").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false);

            equipmentBuilder.Property(e => e.FacilType)
                .HasColumnName("FACILTYPE").HasColumnType("VARCHAR2").HasMaxLength(5).IsUnicode(false);

            equipmentBuilder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(400).IsUnicode(false);

            equipmentBuilder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            equipmentBuilder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);
        }   
    }
}
