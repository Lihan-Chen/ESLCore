using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class ClearanceIssueEntityTypeConfiguration : IEntityTypeConfiguration<ClearanceIssue>
    {
        public void Configure(EntityTypeBuilder<ClearanceIssue> builder)
        {
            builder
                .HasNoKey()
                .ToTable("ESL_CLEARANCEISSUES");

            builder.HasIndex(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo }, "ESL_CLEARANCEISSUES_PK").IsUnique();

            builder.Property(e => e.ClearanceID)
                .HasColumnName("CLEARANCEID").HasColumnType("VARCHAR2").HasMaxLength(20).IsUnicode(false);

            builder.Property(e => e.ClearanceType)
                .HasColumnName("CLEARANCETYPE").HasColumnType("VARCHAR2").HasMaxLength(2).IsUnicode(false);

            builder.Property(e => e.ClearanceZone)
                .HasColumnName("CLEARANCEZONE").HasColumnType("VARCHAR2").HasMaxLength(300).IsUnicode(false);

            builder.Property(e => e.CreatedBy)
                .HasColumnName("CREATEDBY").HasColumnType("NUMBER").HasPrecision(7);
                
            builder.Property(e => e.CreatedDate)
                .HasColumnName("CREATEDDATE").HasColumnType("DATE");

            builder.Property(e => e.EquipmentInvolved)
                .HasColumnName("EQUIPMENTINVOLVED").HasColumnType("VARCHAR2").HasMaxLength(200).IsUnicode(false);

            builder.Property(e => e.EventID)
                .HasColumnName("EVENTID").HasColumnType("VARCHAR2").HasMaxLength(20).IsUnicode(false);

            builder.Property(e => e.EventID_RevNo)
                .HasColumnName("EVENTID_REVNO").HasColumnType("NUMBER").HasPrecision(2);

            builder.Property(e => e.FacilAbbr)
                .HasColumnName("FACILABBR").HasColumnType("VARCHAR2").HasMaxLength(5).IsUnicode(false);

            builder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasColumnType("NUMBER").HasPrecision(2);

            builder.Property(e => e.IssuedBy)
                .HasColumnName("ISSUEDBY").HasColumnType("NUMBER").HasPrecision(7);

            builder.Property(e => e.IssuedDate)
                .HasColumnName("ISSUEDDATE").HasColumnType("DATE");

            builder.Property(e => e.IssuedTime)
                .HasColumnName("ISSUEDTIME").HasColumnType("VARCHAR2").HasMaxLength(5).IsUnicode(false);

            builder.Property(e => e.IssuedTo)
                .HasColumnName("ISSUEDTO").HasColumnType("NUMBER").HasPrecision(7);

            builder.Property(e => e.Location)
                .HasColumnName("LOCATION").HasColumnType("VARCHAR2").HasMaxLength(200).IsUnicode(false);

            builder.Property(e => e.LogTypeNo)
                .HasColumnName("LOGTYPENO").HasColumnType("NUMBER").HasPrecision(2);

            builder.Property(e => e.ModifiedBy)
                .HasColumnName("MODIFIEDBY").HasColumnType("NUMBER").HasPrecision(7);

            builder.Property(e => e.ModifiedDate)
                .HasColumnName("MODIFIEDDATE").HasColumnType("DATE");

            builder.Property(e => e.ModifyFlag)
                .HasColumnName("MODIFYFLAG").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false);

            builder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(400).IsUnicode(false);

            builder.Property(e => e.NotifiedFacil)
                .HasColumnName("NOTIFIEDFACIL").HasColumnType("VARCHAR2").HasMaxLength(200).IsUnicode(false);

            builder.Property(e => e.NotifiedPerson)
                .HasColumnName("NOTIFIEDPERSON").HasColumnType("NUMBER").HasPrecision(7);

            builder.Property(e => e.OperatorID)
                .HasColumnName("OPERATORID").HasColumnType("NUMBER").HasPrecision(7);

            builder.Property(e => e.OperatorType)
                .HasColumnName("OPERATORTYPE").HasColumnType("VARCHAR2").HasMaxLength(15).IsUnicode(false);

            builder.Property(e => e.RelatedTo)
                .HasColumnName("RELATEDTO").HasColumnType("VARCHAR2").HasMaxLength(200).IsUnicode(false);

            builder.Property(e => e.ReleasedBy)
                .HasColumnName("RELEASEDBY").HasColumnType("NUMBER").HasPrecision(7);

            builder.Property(e => e.ReleasedDate)
                .HasColumnName("RELEASEDDATE").HasColumnType("DATE");

            builder.Property(e => e.ReleasedTime)
                .HasColumnName("RELEASEDTIME").HasColumnType("VARCHAR2").HasMaxLength(5).IsUnicode(false);

            builder.Property(e => e.ReleasedTo)
                .HasColumnName("RELEASEDTO").HasColumnType("NUMBER").HasPrecision(7);

            builder.Property(e => e.ReleaseType)
                .HasColumnName("RELEASETYPE").HasColumnType("VARCHAR2").HasMaxLength(30).IsUnicode(false);

            builder.Property(e => e.SeqNo)
                .HasColumnName("SEQNO").HasColumnType("NUMBER").HasPrecision(4);

            builder.Property(e => e.ShiftNo)
                .HasColumnName("SHIFTNO").HasColumnType("NUMBER").HasPrecision(2);
 
            builder.Property(e => e.TagsRemoved)
                .HasColumnName("TAGSREMOVED").HasColumnType("VARCHAR2").HasMaxLength(200).IsUnicode(false);

            builder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            builder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);

            builder.Property(e => e.WorkOrders)
                .HasColumnName("WORKORDERS").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false);

            builder.Property(e => e.WorkToBePerformed)
                .HasColumnName("WORKTOBEPERFORMED").HasColumnType("VARCHAR2").HasMaxLength(600).IsUnicode(false);

            builder.Property(e => e.Yr)
                .HasColumnName("YR").HasColumnType("VARCHAR2").HasMaxLength(2).IsUnicode(false);
                
                
        }
    }
}
