//using System.Reflection.Metadata.Ecma335;

using kudvenkitPractice.DAL;
using kudvenkitPractice.Repositories;
namespace kudvenkitPractice.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly appDbContext context;

        public SQLEmployeeRepository(appDbContext context)
        {
            this.context = context;
        }
        public Employee CreateEmployee(Employee emp)
        {
            context.Employees.Add(emp);
            context.SaveChanges();
            return emp; 
        }

        public Employee DeleteEmployee(int? id)
        {
            Employee DeleteEmp = context.Employees.Find(id);
            if (DeleteEmp != null)
            {
                context.Employees.Remove(DeleteEmp);
                context.SaveChanges();
            }

            return DeleteEmp;

        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return context.Employees;
        }

        public Employee GetEmployee(int id)
        {
            return context.Employees.Find(id);
        }

        public Employee UpdateEmployee(Employee updatedEmp)
        {
            var employee = context.Employees.Attach(updatedEmp);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updatedEmp;  
        }
    }
}
