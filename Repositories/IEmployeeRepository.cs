using kudvenkitPractice.Models;
using Microsoft.Identity.Client;

namespace kudvenkitPractice.Repositories
{

    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployees();
        Employee CreateEmployee(Employee emp);
        Employee UpdateEmployee(Employee empUpdated);
        Employee DeleteEmployee(int? id);
    }

}
