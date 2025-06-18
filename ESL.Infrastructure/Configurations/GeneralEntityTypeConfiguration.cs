using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class GeneralEntityTypeConfiguration : IEntityTypeConfiguration<General>
    {
        public void Configure(EntityTypeBuilder<General> builder)
        {
            builder.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo }).HasName("ESL_GENERAL_PK");

            builder.ToTable("ESL_GENERAL");

            builder.Property(e => e.FacilNo)
                .HasPrecision(2)
                .HasColumnName("FACILNO");
            builder.Property(e => e.LogTypeNo)
                .HasPrecision(2)
                .HasColumnName("LOGTYPENO");
            builder.Property(e => e.EventID)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EVENTID");
            builder.Property(e => e.EventID_RevNo)
                .HasPrecision(2)
                .HasColumnName("EVENTID_REVNO");
            builder.Property(e => e.CreatedBy)
                .HasPrecision(7)
                .HasColumnName("CREATEDBY");
            builder.Property(e => e.CreatedDate)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDDATE");
            builder.Property(e => e.Details)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("DETAILS");
            builder.Property(e => e.EventDate)
                .HasColumnType("DATE")
                .HasColumnName("EVENTDATE");
            builder.Property(e => e.EventTime)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EVENTTIME");
            builder.Property(e => e.Location)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            builder.Property(e => e.ModifiedBy)
                .HasPrecision(7)
                .HasColumnName("MODIFIEDBY");
            builder.Property(e => e.ModifiedDate)
                .HasColumnType("DATE")
                .HasColumnName("MODIFIEDDATE");
            builder.Property(e => e.ModifyFlag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODIFYFLAG");
            builder.Property(e => e.Notes)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("NOTES");
            builder.Property(e => e.NotifiedFacil)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOTIFIEDFACIL");
            builder.Property(e => e.NotifiedPerson)
                .HasPrecision(7)
                .HasColumnName("NOTIFIEDPERSON");
            builder.Property(e => e.OperatorID)
                .HasPrecision(7)
                .HasColumnName("OPERATORID");
            builder.Property(e => e.OperatorType)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("OPERATORTYPE");
            builder.Property(e => e.RelatedTo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("RELATEDTO");
            builder.Property(e => e.ReportedBy)
                .HasPrecision(7)
                .HasColumnName("REPORTEDBY");
            builder.Property(e => e.SeqNo)
                .HasPrecision(6)
                .HasColumnName("SEQNO");
            builder.Property(e => e.ShiftNo)
                .HasPrecision(2)
                .HasColumnName("SHIFTNO");
            builder.Property(e => e.Subject)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
            builder.Property(e => e.UpdateDate)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDATE");
            builder.Property(e => e.UpdatedBy)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("UPDATEDBY");
            builder.Property(e => e.WorkOrders)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WORKORDERS");
            builder.Property(e => e.Yr)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("YR");
        }
    }
}
