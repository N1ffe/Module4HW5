namespace Module4HW5.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HiredDate { get; set; }
        public DateOnly? DateOfBirth { get; set; }

        // * employees belong to 1 office
        public int OfficeId { get; set; }
        public virtual Office Office { get; set; }

        // * employees have 1 title
        public int TitleId { get; set; }
        public virtual Title Title { get; set; }
        public virtual List<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }
}
