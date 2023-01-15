using Microsoft.EntityFrameworkCore;
using Module4HW5.Entities;

namespace Module4HW5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var query1 = db.Employees.Select(e => new { e.FirstName, e.LastName, Location = e.Office.Location, Title = e.Title.Name }).DefaultIfEmpty();
                Console.WriteLine(query1.ToQueryString());
                Console.WriteLine();
                foreach (var e in query1.ToList())
                {
                    Console.WriteLine($"{e.FirstName} {e.LastName} {e.Location} {e.Title}");
                }
                Console.WriteLine();

                var query2 = db.Employees.Select(e => new { EmployeeId = e.EmployeeId, FirstName = e.FirstName, LastName = e.LastName, Experience = (DateTime.Now - e.HiredDate).Days });
                Console.WriteLine(query2.ToQueryString());
                Console.WriteLine();
                foreach (var e in query2.ToList())
                {
                    Console.WriteLine($"{e.EmployeeId} {e.FirstName} {e.LastName} {e.Experience}");
                }
                Console.WriteLine();

                var transaction = db.Database.BeginTransaction();
                try
                {
                    var employee1 = db.Employees.Where(e => e.EmployeeId == 1).FirstOrDefault();
                    employee1.DateOfBirth = new DateOnly(1998, 4, 18);
                    var employee2 = db.Employees.Where(e => e.EmployeeId == 2).FirstOrDefault();
                    employee2.DateOfBirth = new DateOnly(1994, 8, 22);
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    transaction.Rollback();
                }

                transaction = db.Database.BeginTransaction();
                try
                {
                    Employee employee = new Employee() { FirstName = "test_first_name3", LastName = "test_last_name3", HiredDate = new DateTime(2023, 1, 11), OfficeId = 2, TitleId = 3 };
                    db.Add(employee);
                    db.SaveChanges();

                    Project project = new Project() { Name = "test_project_name4", Budget = 750m, StartedDate = new DateTime(2023, 1, 14) };
                    db.Add(project);
                    db.SaveChanges();

                    db.Add(new EmployeeProject() { Rate = 7500m, StartedDate = new DateTime(2023, 1, 14), EmployeeId = employee.EmployeeId, ProjectId = project.ProjectId });
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    transaction.Rollback();
                }

                transaction = db.Database.BeginTransaction();
                try
                {
                    var employee = db.Employees.Where(e => e.EmployeeId == 1).FirstOrDefault();
                    db.Employees.Remove(employee);
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    transaction.Rollback();
                }

                // string.Contains() does not work?
                // var query3 = db.Employees.GroupBy(e => e.Title).Where(e => !e.Key.Name.Contains('a')).Select(e => new { Title = e.Key.Name, Employees = e.Count() }).DefaultIfEmpty();
                var query3 = db.Employees.GroupBy(e => e.Title).Select(e => new { Title = e.Key.Name, Employees = e.Count() }).DefaultIfEmpty();
                Console.WriteLine(query3.ToQueryString());
                Console.WriteLine();
                foreach (var e in query3.ToList())
                {
                    Console.WriteLine($"{e.Title} {e.Employees}");
                }
                Console.WriteLine();
            }
        }
    }
}