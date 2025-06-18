using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class FlowChangeEntityTypeConfiguration : IEntityTypeConfiguration<FlowChange>
    {
        public void Configure(EntityTypeBuilder<FlowChange> builder)
        {
            builder.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo }).HasName("ESL_FLOWCHANGES_PK");

            builder.ToTable("ESL_FLOWCHANGES");

            builder.Property(e => e.FacilNo).HasColumnName("FACILNO").HasPrecision(2);
            builder.Property(e => e.LogTypeNo).HasColumnName("LOGTYPENO").HasPrecision(2);
            builder.Property(e => e.EventID).HasColumnName("EVENTID")
                .HasMaxLength(20)
                .IsUnicode(false);
            builder.Property(e => e.EventID_RevNo).HasColumnName("EVENTID_REVNO").HasPrecision(2);
            builder.Property(e => e.Accepted).HasColumnName("ACCEPTED")
                .HasMaxLength(10)
                .IsUnicode(false);
            builder.Property(e => e.ChangeBy).HasColumnName("CHANGEBY")
                .HasMaxLength(10)
                .IsUnicode(false);
            builder.Property(e => e.ChangeByUnit).HasColumnName("CHANGEBYUNIT")
                .HasMaxLength(10)
                .IsUnicode(false);
            builder.Property(e => e.CreatedBy).HasColumnName("CREATEDBY").HasPrecision(7);
            builder.Property(e => e.CreatedDate).HasColumnName("CREATEDDATE").HasColumnType("DATE");
            builder.Property(e => e.EventDate).HasColumnName("EVENTDATE").HasColumnType("DATE");
            builder.Property(e => e.EventTime).HasColumnName("EVENTTIME")
                .HasMaxLength(5)
                .IsUnicode(false);
            builder.Property(e => e.MeterID).HasColumnName("METERID")
                .HasMaxLength(30)
                .IsUnicode(false);
            builder.Property(e => e.ModifiedBy).HasColumnName("MODIFIEDBY").HasPrecision(7);
            builder.Property(e => e.ModifiedDate).HasColumnName("MODIFIEDDATE").HasColumnType("DATE");
            builder.Property(e => e.ModifyFlag).HasColumnName("MODIFYFLAG")
                .HasMaxLength(100)
                .IsUnicode(false);
            //builder.Property(e => e.NewValue).HasColumnName("NEWVALUE").HasColumnType("NUMBER(10,2)");
            builder.OwnsOne(e => e.NewFlow, flow =>
            {
                flow.Property(f => f.Value).HasColumnName("NEWVALUE").HasColumnType("NUMBER(10,2)");
                flow.Property(f => f.Unit).HasColumnName("UNIT")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            builder.OwnsOne(e => e.OldFlow, flow =>
            {
                flow.Property(f => f.Value).HasColumnName("OLDVALUE").HasColumnType("NUMBER(10,2)");
                flow.Property(f => f.Unit).HasColumnName("OLDUNIT")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            builder.Ignore(e => e.ChangeByFlow);

            //entity.OwnsOne(e => e.ChangeByFlow, flow =>
            //{
            //    flow.Ignore(e => e.Value);
            //    // flow.Property(f => f.Value).HasColumnName("CHANGEBYVALUE").HasColumnType("NUMBER(10,2)");
            //    flow.Property(f => f.Unit).HasColumnName("CHANGEBYUNIT")
            //        .HasMaxLength(10)
            //        .IsUnicode(false);
            //});

            //entity.OwnsOne(e => e.ChangeByFlow, flow =>
            //{
            //    flow.Property(f => f.Value.ToString()).HasColumnName("CHANGEBYVALUE").HasMaxLength(10);
            //    flow.Property(f => f.Unit).HasColumnName("CHANGEBYUNIT")
            //        .HasMaxLength(10)
            //        .IsUnicode(false);
            //});

            builder.Property(e => e.Notes).HasColumnName("NOTES")
                .HasMaxLength(400)
                .IsUnicode(false);
            builder.Property(e => e.NotifiedFacil).HasColumnName("NOTIFIEDFACIL")
                .HasMaxLength(200)
                .IsUnicode(false);
            builder.Property(e => e.NotifiedPerson).HasColumnName("NOTIFIEDPERSON").HasPrecision(7);
            builder.Property(e => e.OffTime).HasColumnName("OFFTIME")
                .HasMaxLength(5)
                .IsUnicode(false);


            //builder.Property(e => e.OldUnit).HasColumnName("OLDUNIT")
            //    .HasMaxLength(10)
            //    .IsUnicode(false);
            //builder.Property(e => e.OldValue).HasColumnName("OLDVALUE").HasColumnType("NUMBER(10,2)");
            builder.Property(e => e.OperatorID).HasColumnName("OPERATORID").HasPrecision(7);
            builder.Property(e => e.OperatorType).HasColumnName("OPERATORTYPE")
                .HasMaxLength(15)
                .IsUnicode(false);
            builder.Property(e => e.RelatedTo).HasColumnName("RELATEDTO")
                .HasMaxLength(200)
                .IsUnicode(false);
            builder.Property(e => e.RequestedBy).HasColumnName("REQUESTEDBY").HasPrecision(7);
            builder.Property(e => e.RequestedDate).HasColumnName("REQUESTEDDATE").HasColumnType("DATE");
            builder.Property(e => e.RequestedTime).HasColumnName("REQUESTEDTIME")
                .HasMaxLength(5)
                .IsUnicode(false);
            builder.Property(e => e.RequestedTo).HasColumnName("REQUESTEDTO").HasPrecision(7);
            builder.Property(e => e.SeqNo).HasColumnName("SEQNO").HasPrecision(6);
            builder.Property(e => e.ShiftNo).HasColumnName("SHIFTNO").HasPrecision(2);
            //builder.Property(e => e.Unit).HasColumnName("UNIT")
            //    .HasMaxLength(10)
            //    .IsUnicode(false);

            builder.OwnsOne(e => e.Update, update =>
            {
                update.Property(e => e.UPDATEDBY).HasColumnName("UPDATEDBY").HasMaxLength(60);
                update.Property(e => e.UPDATEDATE).HasColumnName("UPDATEDATE").HasColumnType("DATE");
            });

            //builder.Property(e => e.UpdateDate).HasColumnName("UPDATEDATE").HasColumnType("DATE");
            //builder.Property(e => e.UpdatedBy).HasColumnName("UPDATEDBY")
            //    .HasMaxLength(60)
            //    .IsUnicode(false);

            builder.Property(e => e.WorkOrders).HasColumnName("WORKORDERS")
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Yr).HasColumnName("YR")
                .HasMaxLength(2)
                .IsUnicode(false);
        }
    }
}

    //builder.Property(e => e.FacilNo)
    //    .HasColumnName("FACILNO").HasPrecision(2);

    //builder.Property(e => e.LogTypeNo)
    //    .HasColumnName("LOGTYPENO").HasPrecision(2);

    //builder.Property(e => e.EventID)
    //    .HasColumnName("EVENTID").HasColumnType("VARCHAR2").HasMaxLength(20).IsUnicode(false);

    //builder.Property(e => e.EventID_RevNo)
    //    .HasColumnName("EVENTID_REVNO").HasPrecision(2);

    //builder.Property(e => e.Accepted)
    //    .HasColumnName("ACCEPTED").HasColumnType("VARCHAR2").HasMaxLength(10).IsUnicode(false);

    //builder.Property(e => e.ChangeBy)
    //    .HasColumnName("CHANGEBY").HasColumnType("VARCHAR2").HasMaxLength(10).IsUnicode(false);

    //builder.Property(e => e.ChangeByUnit)
    //    .HasColumnName("CHANGEBYUNIT").HasColumnType("VARCHAR2").HasMaxLength(10).IsUnicode(false);

    //builder.Property(e => e.CreatedBy)
    //    .HasColumnName("CREATEDBY").HasPrecision(7);

    //builder.Property(e => e.CreatedDate)
    //    .HasColumnName("CREATEDDATE").HasColumnType("DATE");

    //builder.Property(e => e.EventDate)
    //    .HasColumnName("EVENTDATE").HasColumnType("DATE");

    //builder.Property(e => e.EventTime)
    //    .HasColumnName("EVENTTIME").HasColumnType("VARCHAR2").HasMaxLength(5).IsUnicode(false);

    //builder.Property(e => e.MeterID)
    //    .HasColumnName("METERID").HasColumnType("VARCHAR2").HasMaxLength(30).IsUnicode(false);

    //builder.Property(e => e.ModifiedBy)
    //    .HasColumnName("MODIFIEDBY").HasPrecision(7);

    //builder.Property(e => e.ModifiedDate)
    //    .HasColumnName("MODIFIEDDATE").HasColumnType("DATE");

    //builder.Property(e => e.ModifyFlag)
    //    .HasColumnName("MODIFYFLAG").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false);

    ////builder.Property(e => e.NewValue)
    ////    .HasColumnName("NEWVALUE").HasColumnType("NUMBER(10,2)");
    //////    .HasConversion(decimalValue => (double)decimalValue, doubleValue => (decimal)doubleValue);

    //builder.Property(e => e.Notes)
    //    .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(400).IsUnicode(false);

    //builder.Property(e => e.NotifiedFacil)
    //    .HasColumnName("NOTIFIEDFACIL").HasColumnType("VARCHAR2").HasMaxLength(200).IsUnicode(false);

    //builder.Property(e => e.NotifiedPerson)
    //    .HasColumnName("NOTIFIEDPERSON").HasPrecision(7);

    //builder.Property(e => e.OffTime)
    //    .HasColumnName("OFFTIME").HasColumnType("VARCHAR2").HasMaxLength(5).IsUnicode(false);

    //builder.Property(e => e.OldUnit)
    //    .HasColumnName("OLDUNIT").HasColumnType("VARCHAR2").HasMaxLength(10).IsUnicode(false);

    ////builder.Property(e => e.OldValue)
    ////    .HasColumnName("OLDVALUE").HasColumnType("NUMBER(10,2)");
    //////    //.HasConversion(v => Convert.ToDecimal(v), v => v);
    //////    .HasConversion(decimalValue => (double)decimalValue, doubleValue => (decimal)doubleValue);

    //builder.Property(e => e.OperatorID)
    //    .HasColumnName("OPERATORID").HasPrecision(7);

    //builder.Property(e => e.OperatorType)
    //    .HasColumnName("OPERATORTYPE").HasColumnType("VARCHAR2").HasMaxLength(15).IsUnicode(false);

    //builder.Property(e => e.RelatedTo)
    //    .HasColumnName("RELATEDTO").HasColumnType("VARCHAR2").HasMaxLength(200).IsUnicode(false);

    //builder.Property(e => e.RequestedBy)
    //    .HasColumnName("REQUESTEDBY").HasPrecision(7);

    //builder.Property(e => e.RequestedDate)
    //    .HasColumnName("REQUESTEDDATE").HasColumnType("DATE");

    //builder.Property(e => e.RequestedTime)
    //    .HasColumnName("REQUESTEDTIME").HasColumnType("VARCHAR2").HasMaxLength(5).IsUnicode(false);

    //builder.Property(e => e.RequestedTo)
    //    .HasColumnName("REQUESTEDTO").HasPrecision(7);

    //builder.Property(e => e.SeqNo)
    //    .HasColumnName("SEQNO").HasColumnType("NUMBER").HasPrecision(4);

    //builder.Property(e => e.ShiftNo)
    //    .HasColumnName("SHIFTNO").HasColumnType("NUMBER").HasPrecision(2);

    //builder.Property(e => e.Unit)
    //    .HasColumnName("UNIT").HasColumnType("VARCHAR2").HasMaxLength(10).IsUnicode(false);

    //builder.Property(e => e.UpdateDate)
    //    .HasColumnName("UPDATEDATE").HasColumnType("DATE");

    //builder.Property(e => e.UpdatedBy)
    //    .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);

    //builder.Property(e => e.WorkOrders)
    //    .HasColumnName("WORKORDERS").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false);

    //builder.Property(e => e.Yr)
    //    .HasColumnName("YR").HasColumnType("VARCHAR2").HasMaxLength(2).IsUnicode(false);


    // ValueConverter https://learn.microsoft.com/en-us/ef/core/modeling/value-conversions?tabs=data-annotations

