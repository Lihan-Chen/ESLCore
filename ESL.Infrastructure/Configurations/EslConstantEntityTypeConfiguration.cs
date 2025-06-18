using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class EslConstantEntityTypeConfiguration : IEntityTypeConfiguration<EslConstant>
    {
        public void Configure(EntityTypeBuilder<EslConstant> constantBuilder)
        {
            // Table
            constantBuilder.HasNoKey()
                .ToTable("ESL_CONSTANTS");

            // Primary key
            //constantBuilder.HasKey(e => e.FacilNo).HasName("FACILITIES_PK");

            // Indexes
            constantBuilder.HasIndex(e => new { e.FacilNo, e.ConstantName, e.StartDate }, "ESL_CONSTANTS_PK").IsUnique();

            // Properties
            constantBuilder.Property(e => e.ConstantName)
                .HasColumnName("CONSTANTNAME").HasColumnType("VARCHAR2").HasMaxLength(20).IsUnicode(false);

            constantBuilder.Property(e => e.EndDate)
                .HasColumnName("ENDDATE").HasColumnType("DATE");
                
            constantBuilder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasColumnType("NUMBER").HasPrecision(2);

            constantBuilder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(400).IsUnicode(false);
                               
            constantBuilder.Property(e => e.StartDate)
                .HasColumnName("STARTDATE").HasColumnType("DATE");
                
            constantBuilder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            constantBuilder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);

            constantBuilder.Property(e => e.Value)
                .HasColumnName("VALUE").HasColumnType("NUMBER");                
        }
    }
}
