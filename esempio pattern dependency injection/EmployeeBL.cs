using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esempio_pattern_dependency_injection
{
    internal class EmployeeBL
    {
        public IEmployeeDAL employeeDAL;

        public EmployeeBL(IEmployeeDAL employeeDAL) 
        { 
            this.employeeDAL = employeeDAL;
        }

        public List<Employee> GetAllEmployees()
        {
            //Creating an Instance of Dependency Class means it is a Tight Coupling
            employeeDAL = new EmployeeDAL();
            return employeeDAL.SelectAllEmployees();
        }
    }
}
