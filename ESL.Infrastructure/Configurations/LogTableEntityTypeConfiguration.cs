using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class LogTableEntityTypeConfiguration : IEntityTypeConfiguration<LogTable>
    {
        public void Configure(EntityTypeBuilder<LogTable> logTableBuilder)
        {
            // Table
            logTableBuilder.ToTable("ESL_LOGTABLENAMES");

            // Primary key
            logTableBuilder.HasKey(e => e.LogTypeNo).HasName("ESL_LOGNAMES_PK");

            // Indexes
            // Properties
            logTableBuilder.Property(e => e.LogTypeNo)
                .HasColumnName("LOGTYPENO").HasColumnType("NUMBER").HasPrecision(2);

            logTableBuilder.Property(e => e.LogTableName)
                .HasColumnName("LOGTABLENAME").HasColumnType("VARCHAR2").HasMaxLength(30).IsUnicode(false);
        }
    }
}
