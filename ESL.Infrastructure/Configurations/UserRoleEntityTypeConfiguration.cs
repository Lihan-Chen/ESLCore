using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class UserRoleEntityTypeConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> userRoleBuilder)
        {
            // Table
            userRoleBuilder.ToTable("ESL_ALLSCADAUSERS_ROLE", "ESL");

            // Primary key
            userRoleBuilder.HasNoKey();

            // Indexes
            userRoleBuilder.HasIndex(e => new { e.FacilNo, e.UserID }, "ESL_ALLSCADAUSERS_USERID_IDX");

            // Properties
            userRoleBuilder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasColumnType("NUMBER(38)").IsRequired();

            userRoleBuilder.Property(e => e.UserID)
                .HasColumnName("USERID").HasColumnType("VARCHAR2").HasMaxLength(30).IsUnicode(false).IsRequired();

            userRoleBuilder.Property(e => e.Role)
                .HasColumnName("ROLE").HasColumnType("VARCHAR2").HasMaxLength(30).IsUnicode(false).IsRequired();

            userRoleBuilder.Property(e => e.AdminOption)
                .HasColumnName("ADMIN_OPTION").HasColumnType("VARCHAR2").HasMaxLength(3).IsUnicode(false);

            userRoleBuilder.Property(e => e.DefaultRole)
                .HasColumnName("DEFAULT_ROLE").HasColumnType("VARCHAR2").HasMaxLength(3).IsUnicode(false);

            userRoleBuilder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            userRoleBuilder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(20).IsUnicode(false);
        }
    }        
}
