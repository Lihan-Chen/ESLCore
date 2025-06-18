using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class ScanDocEntityTypeConfiguration : IEntityTypeConfiguration<ScanDoc>
    {
        public void Configure(EntityTypeBuilder<ScanDoc> scanDocBuilder)
        {
            scanDocBuilder
                .HasNoKey()
                .ToTable("ESL_SCANDOCS");

            scanDocBuilder.HasIndex(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.ScanNo }, "ESL_SCANDOCS_PK").IsUnique();

            scanDocBuilder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasColumnType("NUMBER").HasPrecision(2);

            scanDocBuilder.Property(e => e.EventID)
                .HasColumnName("EVENTID").HasColumnType("VARCHAR2").HasMaxLength(20).IsUnicode(false);

            scanDocBuilder.Property(e => e.LogTypeNo)
                .HasColumnName("LOGTYPENO").HasColumnType("NUMBER").HasPrecision(2);

            scanDocBuilder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(400).IsUnicode(false);

            scanDocBuilder.Property(e => e.ScanFileName)
                .HasColumnName("SCANFILENAME").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false);

            scanDocBuilder.Property(e => e.ScanNo)
                .HasColumnName("SCANNO").HasColumnType("NUMBER").HasPrecision(2);

            scanDocBuilder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            scanDocBuilder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);
        }
    }
}
