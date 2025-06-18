using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class ScanLobEntityTypeConfiguration : IEntityTypeConfiguration<ScanLob>
    {
        public void Configure(EntityTypeBuilder<ScanLob> scanLobBuilder)
        {
            // Table
            scanLobBuilder.ToTable("ESL_SCANLOBS");

            // Primary key
            scanLobBuilder.HasKey(e => e.ScanSeqNo).HasName("ESL_SCANLOBS_PK");

            // Index
            scanLobBuilder.HasIndex(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.ScanNo }, "SCANLOB_DOC_IDX");

            // Properties

            scanLobBuilder.Property(e => e.ScanSeqNo)
                .HasColumnName("SCANSEQNO").HasColumnType("NUMBER(38)").IsRequired();

            scanLobBuilder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasColumnType("NUMBER").HasPrecision(2);

            scanLobBuilder.Property(e => e.LogTypeNo)
                .HasColumnName("LOGTYPENO").HasColumnType("NUMBER").HasPrecision(2);

            scanLobBuilder.Property(e => e.EventID)
                .HasColumnName("EVENTID").HasColumnType("VARCHAR2").HasMaxLength(20).IsUnicode(false);

            scanLobBuilder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false);

            scanLobBuilder.Property(e => e.ScanBlob)
                .HasColumnName("SCANBLOB").HasColumnType("BLOB").HasDefaultValueSql("EMPTY_BLOB()");

            scanLobBuilder.Property(e => e.ScanFileName)
                .HasColumnName("SCANFILENAME").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false);

            scanLobBuilder.Property(e => e.ScanLobType)
                .HasColumnName("SCANLOBTYPE").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false);

            scanLobBuilder.Property(e => e.ScanNo)
                .HasColumnName("SCANNO").HasColumnType("NUMBER").HasPrecision(2);

            scanLobBuilder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);

            scanLobBuilder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");
        }
    }
}
