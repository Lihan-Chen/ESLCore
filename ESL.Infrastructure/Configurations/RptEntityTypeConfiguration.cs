using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class RptEntityTypeConfiguration : IEntityTypeConfiguration<Rpt>
    {
        public void Configure(EntityTypeBuilder<Rpt> builder)
        {
            builder
                .HasNoKey()
                .ToTable("ESL_RPT_ALLEVENTS");

            builder.Property(e => e.FacilName)
                .HasColumnName("FACILNAME").HasColumnType("VARCHAR2").HasMaxLength(40).IsUnicode(false);

            builder.Property(e => e.LogTypeName)
                .HasColumnName("LOGTYPENAME").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false);
            
            builder.Property(e => e.EventID)
                .HasColumnName("EVENTID").HasColumnType("VARCHAR2").HasMaxLength(20).IsUnicode(false);
                        
            builder.Property(e => e.EventID_RevNo)
                .HasColumnName("EVENTID_REVNO").HasColumnType("NUMBER").HasPrecision(2);

            builder.Property(e => e.EventDate)
                .HasColumnName("EVENTDATE").HasColumnType("DATE");

            builder.Property(e => e.EventTime)
                .HasColumnName("EVENTTIME").HasColumnType("VARCHAR2").HasMaxLength(5).IsUnicode(false);

            builder.Property(e => e.Subject)
                .HasColumnName("SUBJECT").HasColumnType("VARCHAR2").HasMaxLength(120).IsUnicode(false);

            builder.Property(e => e.Details)
                .HasColumnName("DETAILS").HasColumnType("VARCHAR2").HasMaxLength(2000).IsUnicode(false);

            builder.Property(e => e.UpdatedByName)
                .HasColumnName("UPDATEDBYNAME").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);
        
            builder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");
            
            builder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasColumnType("NUMBER").HasPrecision(2);

            builder.Property(e => e.LogTypeNo)
                .HasColumnName("LOGTYPENO").HasColumnType("NUMBER").HasPrecision(2);
        }
    }
}
