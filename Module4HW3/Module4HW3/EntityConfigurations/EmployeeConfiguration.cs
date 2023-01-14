using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW5.Entities;

namespace Module4HW5.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee").HasKey(e => e.EmployeeId);
            builder.Property(e => e.EmployeeId).ValueGeneratedOnAdd();
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.HiredDate).IsRequired();
            builder.HasOne(o => o.Office).WithMany(e => e.Employees).HasForeignKey(o => o.OfficeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(t => t.Title).WithMany(e => e.Employees).HasForeignKey(t => t.TitleId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
