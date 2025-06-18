using ESL.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.Configurations
{
    public class Outstanding_GeneralEntityTypeConfiguration : IEntityTypeConfiguration<Outstanding_General>
    {
        public void Configure(EntityTypeBuilder<Outstanding_General> builder)
        {
            builder.HasNoKey().ToView("VIEW_GENERAL_OUTSTANDING");

            builder.Property(e => e.EventID)
                .HasColumnName("EVENTID")
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.EventID_RevNo)
                .HasColumnName("EVENTID_REVNO").HasPrecision(2);

            builder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO")
                .HasPrecision(2);

            builder.Property(e => e.LogTypeNo)
                .HasColumnName("LOGTYPENO")
                .HasPrecision(2);

            builder.Property(e => e.EventDate)
                .HasColumnName("EVENTDATE")
                .HasColumnType("DATE");

            builder.Property(e => e.EventTime)
                .HasColumnName("EVENTTIME")
                .HasMaxLength(5)
                .IsUnicode(false);

            builder.Property(e => e.Subject)
                .HasColumnName("SUBJECT")
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.Property(e => e.Details)
                .HasColumnName("DETAILS")
                .HasMaxLength(2000)
                .IsUnicode(false);

            builder.Property(e => e.LogTypeName)
                .HasColumnName("LOGTYPENAME")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.FacilName)
                .HasColumnName("FACILNAME")
                .HasMaxLength(40)
                .IsUnicode(false);

            builder.OwnsOne(e => e.Update, update =>
            {
                update.Property(e => e.UPDATEDBY).HasColumnName("UPDATEDBY").HasMaxLength(60);
                update.Property(e => e.UPDATEDATE).HasColumnName("UPDATEDATE").HasColumnType("DATE");
            });

            builder.Property(e => e.OperatorType)
                .HasColumnName("OPERATORTYPE")
                .HasMaxLength(15)
                .IsUnicode(false);

            builder.Property(e => e.ScanDocsNo)
                .HasColumnName("SCANDOCSNO")
                .HasColumnType("NUMBER");
        }
    }
}
