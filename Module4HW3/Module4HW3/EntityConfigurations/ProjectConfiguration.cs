using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW5.Entities;

namespace Module4HW5.EntityConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project").HasKey(p => p.ProjectId);
            builder.Property(p => p.ProjectId).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Budget).IsRequired().HasColumnType("money");
            builder.Property(p => p.StartedDate).IsRequired();

            builder.HasData(new List<Project>()
            {
                new Project() { ProjectId = 1, Name = "test_project_name1", Budget = 500m, StartedDate = new DateTime(2022, 12, 05) },
                new Project() { ProjectId = 2, Name = "test_project_name2", Budget = 1500m, StartedDate = new DateTime(2022, 10, 01) },
                new Project() { ProjectId = 3, Name = "test_project_name3", Budget = 1000m, StartedDate = new DateTime(2022, 12, 20) }
            });
        }
    }
}
