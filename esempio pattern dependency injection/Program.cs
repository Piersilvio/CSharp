namespace esempio_pattern_dependency_injection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create an Instance of EmployeeBL and Inject the Dependency Object as an Argument to the Constructor
            EmployeeBL employeeBL = new EmployeeBL(new EmployeeDAL());
            List<Employee> ListEmployee = employeeBL.GetAllEmployees();

            foreach (Employee emp in ListEmployee)
            {
                Console.WriteLine($"ID = {emp.ID}, Name = {emp.Name}, Department = {emp.Department}");
            }
            Console.ReadKey();
        }
    }
}