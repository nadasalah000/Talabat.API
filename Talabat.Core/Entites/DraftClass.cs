using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entites
{
    public class Employee :BaseEntity
    {
        public string Name { get; set; }
        public string Salary { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
