namespace Module4HW5.Entities
{
    public class Title
    {
        public int TitleId { get; set; }
        public string Name { get; set; }
        public virtual List<Employee> Employees { get; set; } = new List<Employee>(); // 1 title belongs to * employees
    }
}
