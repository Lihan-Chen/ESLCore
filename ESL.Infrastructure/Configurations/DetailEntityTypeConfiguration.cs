using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class DetailEntityTypeConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> detailBuilder)
        {
            // Table
            detailBuilder.HasNoKey()
                .ToTable("ESL_DETAILS");

            // Primary key
            //constantBuilder.HasKey(e => e.FacilNo).HasName("FACILITIES_PK");

            // Indexes
            detailBuilder.HasIndex(e => new { e.FacilNo, e.DetailsNo }, "ESL_DETAILS_PK").IsUnique();

            // Properties
            detailBuilder.Property(e => e.DetailsName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DETAILSNAME");

            detailBuilder.Property(e => e.DetailsNo)
                .HasColumnName("DETAILSNO").HasColumnType("NUMBER").HasPrecision(3);

            detailBuilder.Property(e => e.Disable)
                .HasColumnName("DISABLE").HasColumnType("VARCHAR2").HasMaxLength(30).IsUnicode(false);

            detailBuilder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasColumnType("NUMBER").HasPrecision(3);

            detailBuilder.Property(e => e.FacilType)
                .HasColumnName("FACILTYPE").HasColumnType("VARCHAR2").HasMaxLength(5).IsUnicode(false);

            detailBuilder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(400).IsUnicode(false);

            detailBuilder.Property(e => e.SortNo)
                .HasColumnName("SORTNO").HasColumnType("NUMBER").HasPrecision(2);

            detailBuilder.Property(e => e.SubjNo)
                .HasColumnName("SUBJNO").HasColumnType("NUMBER").HasPrecision(2);

            detailBuilder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            detailBuilder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);
        }
    }
}
