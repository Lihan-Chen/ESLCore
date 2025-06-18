using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class EOSEntityTypeConfiguration : IEntityTypeConfiguration<EOS>
    {
        public void Configure(EntityTypeBuilder<EOS> builder)
        {
            builder.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo }).HasName("ESL_EOS_PK");

            builder.ToTable("ESL_EOS");

            builder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasColumnType("NUMBER").HasPrecision(2);

            builder.Property(e => e.LogTypeNo)
                .HasColumnName("LOGTYPENO").HasColumnType("NUMBER").HasPrecision(2);

            builder.Property(e => e.EventID)
                .HasColumnName("EVENTID").HasColumnType("VARCHAR2").HasMaxLength(20).IsUnicode(false);

            builder.Property(e => e.EventID_RevNo)
                .HasColumnName("EVENTID_REVNO").HasColumnType("NUMBER").HasPrecision(2);

            builder.Property(e => e.CreatedBy)
                .HasColumnName("CREATEDBY").HasColumnType("NUMBER").HasPrecision(7);

            builder.Property(e => e.CreatedDate)
                .HasColumnName("CREATEDDATE").HasColumnType("DATE");

            builder.Property(e => e.EquipmentInvolved)
                .HasColumnName("EQUIPMENTINVOLVED").HasColumnType("VARCHAR2").HasMaxLength(120).IsUnicode(false);

            builder.Property(e => e.Location)
                .HasColumnName("LOCATION").HasColumnType("VARCHAR2").HasMaxLength(200).IsUnicode(false); ;

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

            builder.Property(e => e.ReleaseType)
                .HasColumnName("RELEASETYPE").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false);

            builder.Property(e => e.ReportedBy)
                .HasColumnName("REPORTEDBY").HasColumnType("NUMBER").HasPrecision(7);

            builder.Property(e => e.ReportedDate)
                .HasColumnName("REPORTEDDATE").HasColumnType("DATE");

            builder.Property(e => e.ReportedTime)
                .HasColumnName("REPORTEDTIME").HasColumnType("VARCHAR2").HasMaxLength(5).IsUnicode(false); ;

            builder.Property(e => e.ReportedTo)
                .HasColumnName("REPORTEDTO").HasColumnType("NUMBER").HasPrecision(7);

            builder.Property(e => e.SeqNo)
                .HasColumnName("SEQNO").HasColumnType("NUMBER").HasPrecision(4);

            builder.Property(e => e.ShiftNo)
                .HasColumnName("SHIFTNO").HasColumnType("NUMBER").HasPrecision(2);

            builder.Property(e => e.TagsInstalled)
                .HasColumnName("TAGSINSTALLED").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false); ;

            builder.Property(e => e.TagsRemoved)
                .HasColumnName("TAGSREMOVED").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false);

            builder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            builder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);

            builder.Property(e => e.WorkOrders)
                .HasColumnName("WORKORDERS").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false);

            builder.Property(e => e.Yr)
                .HasColumnName("YR").HasColumnType("VARCHAR2").HasMaxLength(2).IsUnicode(false);
        }
    }
}
