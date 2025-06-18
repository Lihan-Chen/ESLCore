using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class WorkTBPEntityTypeConfiguration : IEntityTypeConfiguration<WorkTBP>
    { 
        public void Configure(EntityTypeBuilder<WorkTBP> workTBPBuilder)
        {
            // Table
            workTBPBuilder.ToTable("ESL_WORKTOBEPERFORMED");

            // Primary key
            workTBPBuilder.HasKey(e => new { e.FacilType, e.WorkNo }).HasName("WORKTOBEPERFORMED_PK");

            // Indexes

            // Properties

            workTBPBuilder.Property(e => e.FacilType)
                .HasColumnName("FACILTYPE").HasColumnType("VARCHAR2").HasMaxLength(5).IsUnicode(false);

            workTBPBuilder.Property(e => e.WorkNo)
                .HasColumnName("WORKNO").HasColumnType("NUMBER").HasPrecision(3);

            workTBPBuilder.Property(e => e.WorkDescription)
                .HasColumnName("WORKDESCRIPTION").HasColumnType("VARCHAR2").HasMaxLength(200).IsUnicode(false);

            workTBPBuilder.Property(e => e.Disable)
                .HasColumnName("DISABLE").HasColumnType("VARCHAR2").HasMaxLength(30).IsUnicode(false);

            workTBPBuilder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(400).IsUnicode(false);

            workTBPBuilder.Property(e => e.SortNo)
                .HasColumnName("SORTNO").HasColumnType("NUMBER").HasPrecision(2);

            workTBPBuilder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            workTBPBuilder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);
        }
    }
}
