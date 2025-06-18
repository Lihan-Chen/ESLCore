using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class LogTypeEntityTypeConfiguration : IEntityTypeConfiguration<LogType>
    {
        public void Configure(EntityTypeBuilder<LogType> logTypeBuilder)
        {
            // Table
            logTypeBuilder.ToTable("ESL_LOGTYPES");

            // Primary key
            logTypeBuilder.HasKey(e => e.LogTypeNo).HasName("ESL_LOGTYPES_PK");

            // Indexes
            logTypeBuilder.HasIndex(e => new { e.LogTypeNo, e.LogTypeName }, "ESL_LOGTYPES_UNQ").IsUnique();

            // Properties
            logTypeBuilder.Property(e => e.LogTypeNo)
                .HasColumnName("LOGTYPENO").HasColumnType("NUMBER").HasPrecision(2);                

            logTypeBuilder.Property(e => e.LogTypeName)
                .HasColumnName("LOGTYPENAME").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false);

            logTypeBuilder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(400).IsUnicode(false);

            logTypeBuilder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            logTypeBuilder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);
        }
    }
}
