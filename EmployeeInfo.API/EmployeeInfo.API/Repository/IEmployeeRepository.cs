using EmployeeInfo.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeInfo.API.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeModel>> GetAllEmployeesAsync();

        Task<EmployeeModel> GetEmployeeByIdAsync(int employeeId);

        Task<int> AddEmployeeAsync(EmployeeModel employeeModel);

        Task UpdateEmployeeAsync(int employeeId, EmployeeModel employeeModel);

        Task DeleteEmployeeAsync(int employeeId);
    }
}
