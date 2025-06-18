using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class SubjectEntityTypeConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> subjectBuilder)
        {
            // Table
            subjectBuilder.ToTable("ESL_SUBJECTS");

            // Primary key
            subjectBuilder.HasKey(e => new { e.FacilNo, e.SubjNo }).HasName("ESL_SUBJECTS_PK");

            // Indexes
            subjectBuilder.HasIndex(e => new { e.FacilNo, e.FacilType, e.SubjName }, "ESL_SUBJECTS_UNQ").IsUnique();

            // Properties
            subjectBuilder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasColumnType("NUMBER").HasPrecision(2);

            subjectBuilder.Property(e => e.SubjNo)
                .HasColumnName("SUBJNO").HasColumnType("NUMBER").HasPrecision(3);

            subjectBuilder.Property(e => e.Disable)
                .HasColumnName("DISABLE").HasColumnType("VARCHAR2").HasMaxLength(30).IsUnicode(false);

            subjectBuilder.Property(e => e.FacilType)
                .HasColumnName("FACILTYPE").HasColumnType("VARCHAR2").HasMaxLength(5).IsUnicode(false);

            subjectBuilder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(400).IsUnicode(false);

            subjectBuilder.Property(e => e.SortNo)
                .HasColumnName("SORTNO").HasColumnType("NUMBER").HasPrecision(2);

            subjectBuilder.Property(e => e.SubjName)
                .HasColumnName("SUBJNAME").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false);

            subjectBuilder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            subjectBuilder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);
        }
    }
}
