using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Meter = ESL.Core.Models.BusinessEntities.Meter;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class MeterEntityTypeConfiguration : IEntityTypeConfiguration<Meter>
    {
        public void Configure(EntityTypeBuilder<Meter> meterBuilder)
        {
            // Table
            meterBuilder.ToTable("ESL_METERS");

            // Primary key
            meterBuilder.HasKey(e => new { e.FacilNo, e.MeterID }).HasName("ESL_METERS_PK");

            // Properties
            meterBuilder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasColumnType("NUMBER").HasPrecision(2);

            meterBuilder.Property(e => e.MeterID)
                .HasColumnName("METERID").HasColumnType("VARCHAR2").HasMaxLength(20).IsUnicode(false);

            meterBuilder.Property(e => e.Disable)
                .HasColumnName("DISABLE").HasColumnType("VARCHAR2").HasMaxLength(30).IsUnicode(false);

            meterBuilder.Property(e => e.MeterType)
                .HasColumnName("METERTYPE").HasColumnType("VARCHAR2").HasMaxLength(20).IsUnicode(false);

            meterBuilder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(15).IsUnicode(false);

            meterBuilder.Property(e => e.SortNo)
                .HasColumnName("SORTNO").HasColumnType("NUMBER").HasPrecision(2);

            meterBuilder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            meterBuilder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);
        }
    }
}
