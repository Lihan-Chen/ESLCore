using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class CalloutTypeEntityTypeConfiguration : IEntityTypeConfiguration<CalloutType>
    {
        public void Configure(EntityTypeBuilder<CalloutType> calloutTypeBuilder)
        {
            // Table
            calloutTypeBuilder.ToTable("ESL_CALLOUTTYPES", "ESL");

            // Primary key
            calloutTypeBuilder.HasKey(e => e.CalloutTypeNo).HasName("ESL_CALLOUTTYPE_PK");

            // Indexes
            calloutTypeBuilder.HasIndex(e => e.CalloutTypeNo, "CALLOUTTYPENO");

            // Properties
            calloutTypeBuilder.Property(e => e.CalloutTypeNo)
                .HasColumnName("CALLOUTTYPENO").HasColumnType("NUMBER(38)");

            calloutTypeBuilder.Property(e => e.CalloutTypeName)
                .HasColumnName("CALLOUTTYPENAME").HasColumnType("VARCHAR2").HasMaxLength(50).IsUnicode(false);

            calloutTypeBuilder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(300).IsUnicode(false);

            calloutTypeBuilder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            calloutTypeBuilder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(20).IsUnicode(false);
        }
    }        
}
