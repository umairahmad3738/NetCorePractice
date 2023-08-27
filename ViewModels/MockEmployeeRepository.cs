using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;
using kudvenkitPractice.Repositories;
using kudvenkitPractice.Models;
//using System.Reflection.Metadata.Ecma335;

namespace kudvenkitPractice.ViewModels
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Department = DepartmentEnums.Physics, Email = "aalu@aalu.com", Name = "Umair", Gender = GenderEnums.Male },
                new Employee() { Id = 2, Department = DepartmentEnums.Physics, Email = "aalu@Kachalu.com", Name = "Ahsan", Gender = GenderEnums.Male},
                new Employee() { Id = 3, Department = DepartmentEnums.Ecommerce,Email = "aalu@pachalu.com", Name = "Saad", Gender = GenderEnums.Male},
                new Employee() { Id = 4, Department = DepartmentEnums.Sexology, Email = "aalu@nachalu.com", Name = "Hasnat", Gender = GenderEnums.Male},
                new Employee() { Id = 5, Department = DepartmentEnums.Psychology, Email = "aalu@tachalu.com", Name = "Fatima", Gender = GenderEnums.Female }
            };
        }
        public Employee CreateEmployee(Employee emp)
        {
            emp.Id = _employeeList.Max(e => e.Id) + 1;
            emp.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(emp.Name.ToLower());
            _employeeList.Add(emp);
            return emp;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(x => x.Id == id);
        }

        public Employee UpdateEmployee(Employee emp)
        {
            Employee updatedEmployee = _employeeList.FirstOrDefault(e => e.Id == emp.Id);
            updatedEmployee.Name = emp.Name;
            updatedEmployee.Gender = emp.Gender;
            updatedEmployee.Department = emp.Department;
            updatedEmployee.Email = emp.Email;
            return updatedEmployee;
        }
        public Employee DeleteEmployee(int? id)
        {

            Employee employee = _employeeList.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }
    }
}
