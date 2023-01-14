using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Module4HW5.Entities;

namespace Module4HW5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName);
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            // testing
            using (ApplicationContext db = new ApplicationContext(options))
            {
                List<Title> titles = db.Titles.ToList();
                foreach (Title title in titles)
                {
                    Console.WriteLine($"{title.TitleId} {title.Name}");
                }
            }
        }
    }
}