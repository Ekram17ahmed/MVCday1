namespace MVCday1.Models
{
    public class Departement
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public DateTime CreatedON { get; private set; }
        public string CreatedBy { get; private set; }
        public bool isDeleted { get; private set; }
        public DateTime? ModifiedON { get; private set; }
        public List<Employee>? Employees { get; set; }
    }
}
