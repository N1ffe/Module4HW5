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

            builder.HasData(new List<EmployeeProject>()
            {
                new EmployeeProject() { EmployeeProjectId = 1, Rate = 500m, StartedDate = new DateTime(2022, 12, 05), EmployeeId = 1, ProjectId = 1 },
                new EmployeeProject() { EmployeeProjectId = 2, Rate = 1500m, StartedDate = new DateTime(2022, 10, 01), EmployeeId = 2, ProjectId = 2 },
                new EmployeeProject() { EmployeeProjectId = 3, Rate = 1000m, StartedDate = new DateTime(2022, 12, 20), EmployeeId = 2, ProjectId = 3 }
            });
        }
    }
}
