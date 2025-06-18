using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ESL.Core.Models.BusinessEntities;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    // https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-builder-framework-core
    class AllEventEntityTypeConfiguration : IEntityTypeConfiguration<AllEvent>
    {
        public void Configure(EntityTypeBuilder<AllEvent> allEventBuilder)
        {
            // Table
            allEventBuilder.ToTable("ESL_ALLEVENTS", "ESL");

            // Primary key
            allEventBuilder.HasKey(e => new { e.FacilNo, e.LogTypeNo, e.EventID, e.EventID_RevNo }).HasName("ESL_ALLEVENTS_PK");

            // Indexes
            allEventBuilder.HasIndex(e => e.UpdateDate, "UPDATEDATE");

            // Properties
            allEventBuilder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasColumnType("NUMBER").HasPrecision(2).IsRequired();

            allEventBuilder.Property(e => e.LogTypeNo)
                .HasColumnName("LOGTYPENO").HasColumnType("NUMBER").HasPrecision(2).IsRequired();

            allEventBuilder.Property(e => e.EventID)
                .HasColumnName("EVENTID").HasColumnType("VARCHAR2").HasMaxLength(20).IsRequired().IsUnicode(false);
                
            allEventBuilder.Property(e => e.EventID_RevNo)                
                .HasColumnName("EVENTID_REVNO").HasColumnType("NUMBER").HasPrecision(2).IsRequired();

            allEventBuilder.Property(e => e.ClearanceID)
                .HasColumnName("CLEARANCEID").HasColumnType("VARCHAR2").HasMaxLength(20).IsUnicode(false);

            allEventBuilder.Property(e => e.Details)
                .HasColumnName("DETAILS").HasColumnType("VARCHAR2").HasMaxLength(2000).IsUnicode(false);

            allEventBuilder.Property(e => e.EventDate)
                .HasColumnName("EVENTDATE").HasColumnType("DATE");

            allEventBuilder.Property(e => e.EventTime)
                .HasColumnName("EVENTTIME").HasColumnType("VARCHAR2").HasMaxLength(5).IsUnicode(false);
                
            allEventBuilder.Property(e => e.ModifyFlag)
                .HasColumnName("MODIFYFLAG").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false);

            allEventBuilder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(400).IsUnicode(false);

            allEventBuilder.Property(e => e.OperatorType)
                .HasColumnName("OPERATORTYPE").HasColumnType("VARCHAR2").HasMaxLength(15).IsUnicode(false);

            allEventBuilder.Property(e => e.Subject)
                .HasColumnName("SUBJECT").HasColumnType("VARCHAR2").HasMaxLength(300).IsUnicode(false);

            allEventBuilder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");
            
            allEventBuilder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);

            // Relationships
            //allEventBuilder.HasOne(p => p.Category)
            //       .WithMany(c => c.Products)
            //       .HasForeignKey(p => p.CategoryId);
            // Other configuration

            //var navigation =
            //allEventBuilder.Metadata.FindNavigation(nameof(Order.OrderItems));

            //EF access the OrderItem collection property through its backing field
            //navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            // Other configuration
        }
    }
}
