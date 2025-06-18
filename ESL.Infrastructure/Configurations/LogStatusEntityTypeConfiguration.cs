using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class LogStatusEntityTypeConfiguration : IEntityTypeConfiguration<LogStatus>
    {
        public void Configure(EntityTypeBuilder<LogStatus> logStatusBuilder)
        {
            // Table
            logStatusBuilder.ToTable("ESL_LOGSTATUS");

            // Primary key
            logStatusBuilder.HasKey(e => e.LogStatusNo).HasName("ESL_LOGSTATUS_PK");

            // Indexes
            
            // Properties
            logStatusBuilder.Property(e => e.LogStatusNo)
                .HasColumnName("LOGSTATUSNO").HasColumnType("NUMBER").HasPrecision(2);

            logStatusBuilder.Property(e => e.Status)
                .HasColumnName("LOGSTATUS").HasColumnType("VARCHAR2").HasMaxLength(20).IsUnicode(false);

            logStatusBuilder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(50).IsUnicode(false);
        }
    }
}
