using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace emphierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<Employee> employees = GetEmployees() as List<Employee>;
            List<Employee> emp = employees.Where(m => m.ManagerId == 0).ToList();
            foreach(var item in emp)
            {
                item.Employees = GetEmployeesList(item.EmployeeId);
                Employee empHierarchy = PullHierarchy(item);
                
            }
            /*emp.Employees = GetEmployeesList(emp.EmployeeId);*/
            

        }
        private static List<Employee> GetEmployeesList(int employeeId)
        {
            List<Employee> employees = GetEmployees() as List<Employee>;
            return employees.Where(m => m.ManagerId == employeeId).ToList();
        }
        private static Employee PullHierarchy(Employee emp)
        {
            foreach (var employee in emp.Employees)
            {
                employee.Employees = GetEmployeesList(employee.EmployeeId);
            }
            return emp;
        }

        private static IEnumerable<Employee> GetEmployees()
        {
            List<Employee> emps = new List<Employee>();
            emps.Add(new Employee { EmployeeId = 1, EmployeeName = "AAA", ManagerId = 0 });
            emps.Add(new Employee { EmployeeId = 2, EmployeeName = "BBB", ManagerId = 1 });
            emps.Add(new Employee { EmployeeId = 3, EmployeeName = "CCC", ManagerId = 1 });
            emps.Add(new Employee { EmployeeId = 4, EmployeeName = "DDD", ManagerId = 2 });
            emps.Add(new Employee { EmployeeId = 5, EmployeeName = "DDD", ManagerId = 0 });

            return emps;
        }

    }
}