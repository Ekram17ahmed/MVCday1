using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCday1.Models
{
    public class Employee
    {
        public Employee(string name, int age, double salary, string createdBy)
        {
            Name = name;
            Age = age;
            Salary = salary;
            CreatedBy = createdBy;
            CreatedON = DateTime.Now;
            isDeleted = false;
        }
        public Employee()
        {
            
        }

        public int Id { get; private set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; private set; }
        public int Age { get; private set; }
        public double Salary { get; private set; }
        public DateTime CreatedON { get; private set; }
        public string CreatedBy { get; private set; }
        public bool isDeleted { get; private set; }
        public DateTime? ModifiedON { get; private set; }
        [ForeignKey("Departement")]
        public int? DeptID { get; private set; }
        public Departement? Departement { get; set; }
        public void Delete()
        {
            isDeleted = true;
        }
        public void Edit(string name , double salary , int age)
        {
            Age = age;
            Name = name;
            Salary = salary;
            ModifiedON = DateTime.Now;
        }
    }
}
