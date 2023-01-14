using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW5.Entities;

namespace Module4HW5.EntityConfigurations
{
    public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.ToTable("EmployeeProject").HasKey(ep => ep.EmployeeProjectId);
            builder.Property(ep => ep.EmployeeProjectId).ValueGeneratedOnAdd();
            builder.Property(ep => ep.Rate).IsRequired().HasColumnType("money");
            builder.Property(ep => ep.StartedDate).IsRequired();
            builder.HasOne(e => e.Employee).WithMany(ep => ep.EmployeeProjects).HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Project).WithMany(ep => ep.EmployeeProjects).HasForeignKey(p => p.ProjectId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
