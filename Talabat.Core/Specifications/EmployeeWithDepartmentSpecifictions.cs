using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;

namespace Talabat.Core.Specifications
{
    public class EmployeeWithDepartmentSpecifictions:BaseSpecifications<Employee>
    {
        public EmployeeWithDepartmentSpecifictions()
        { 
          Includes.Add(E =>E.Department);
        }
        public EmployeeWithDepartmentSpecifictions(int id):base(E=>E.Id ==id)
        {
            Includes.Add(E => E.Department);
        }
    }
}
