using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class WorkOrderEntityTypeConfiguration : IEntityTypeConfiguration<WorkOrder>
    {
        public void Configure(EntityTypeBuilder<WorkOrder> workOrderBuilder)
        {
            // Table
            workOrderBuilder.ToTable("ESL_WORKORDERS");

            // Primary key
            workOrderBuilder.HasNoKey();
            // Indexes
            workOrderBuilder.HasIndex(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.WoNo }, "ESL_WORKORDERS_PK").IsUnique();

            // Properties            
            workOrderBuilder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasColumnType("NUMBER").HasPrecision(2);
                
            workOrderBuilder.Property(e => e.LogTypeNo)
                .HasColumnName("LOGTYPENO").HasColumnType("NUMBER").HasPrecision(2);

            workOrderBuilder.Property(e => e.EventID)
                .HasColumnName("EVENTID").HasColumnType("VARCHAR2").HasMaxLength(20).IsUnicode(false);

            workOrderBuilder.Property(e => e.WoNo)
                .HasColumnName("WO_NO").HasColumnType("VARCHAR2").HasMaxLength(200).IsUnicode(false);

            workOrderBuilder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(400).IsUnicode(false);

            workOrderBuilder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            workOrderBuilder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);
        }
    }
}
