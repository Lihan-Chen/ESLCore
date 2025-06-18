using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESL.Infrastructure.DataAccess.Configurations
{
    class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> employeeBuilder)
        {
            // Table
            employeeBuilder.ToTable("ESL_EMPLOYEES");

            // Primary key
            employeeBuilder.HasKey(e => e.EmployeeNo).HasName("EMPLOYEES_PK");

            // Indexes

            // Properties

            employeeBuilder.Property(e => e.EmployeeNo)
                .HasColumnName("EMPLOYEENO").HasColumnType("NUMBER").HasPrecision(8).ValueGeneratedNever();

            employeeBuilder.Property(e => e.Company)
                .HasColumnName("COMPANY").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false);

            employeeBuilder.Property(e => e.Disable)
                .HasColumnName("DISABLE").HasColumnType("VARCHAR2").HasMaxLength(30).IsUnicode(false);

            employeeBuilder.Property(e => e.FacilNo)
                .HasColumnName("FACILNO").HasColumnType("NUMBER").HasPrecision(3);

            employeeBuilder.Property(e => e.FirstName)
                .HasColumnName("FIRSTNAME").HasColumnType("VARCHAR2").HasMaxLength(50).IsUnicode(false);

            employeeBuilder.Property(e => e.GroupName)
                .HasColumnName("GROUPNAME").HasMaxLength(100).IsUnicode(false);

            employeeBuilder.Property(e => e.JobTitle)
                .HasColumnName("JOBTITLE").HasColumnType("VARCHAR2").HasMaxLength(100).IsUnicode(false);

            employeeBuilder.Property(e => e.LastName)
                .HasColumnName("LASTNAME").HasColumnType("VARCHAR2").HasMaxLength(50).IsUnicode(false);

            employeeBuilder.Property(e => e.Notes)
                .HasColumnName("NOTES").HasColumnType("VARCHAR2").HasMaxLength(400).IsUnicode(false);

            employeeBuilder.Property(e => e.UpdateDate)
                .HasColumnName("UPDATEDATE").HasColumnType("DATE");

            employeeBuilder.Property(e => e.UpdatedBy)
                .HasColumnName("UPDATEDBY").HasColumnType("VARCHAR2").HasMaxLength(60).IsUnicode(false);
        }
    }
}
