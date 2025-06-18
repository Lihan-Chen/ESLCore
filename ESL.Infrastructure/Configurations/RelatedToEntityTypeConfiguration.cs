using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class RelatedToEntityTypeConfiguration : IEntityTypeConfiguration<RelatedTo>
    {
        public void Configure(EntityTypeBuilder<RelatedTo> builder)
        {
            builder
                .HasNoKey()
                .ToTable("ESL_RELATEDTO");

            builder.HasIndex(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.RelatedTo_Subject }, "ESL_RELATEDTO_PK").IsUnique();

            builder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasColumnType("NUMBER").HasPrecision(2);

            builder.Property(e => e.LogTypeNo)
                .HasColumnName("LOGTYPENO").HasColumnType("NUMBER").HasPrecision(2);

            builder.Property(e => e.EventID)
                .HasColumnName("EVENTID").HasColumnType("VARCHAR2").HasMaxLength(20).IsUnicode(false);

            builder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(400).IsUnicode(false);

            builder.Property(e => e.RelatedTo_Subject)
                .HasColumnName("RELATEDTO_SUBJECT").HasColumnType("VARCHAR2").HasMaxLength(120).IsUnicode(false);

            builder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            builder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);
        }
    }
}
