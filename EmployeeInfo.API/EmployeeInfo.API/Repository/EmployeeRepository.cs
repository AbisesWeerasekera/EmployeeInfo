using EmployeeInfo.API.Data;
using EmployeeInfo.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInfo.API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeInfoContext _context;

        public EmployeeRepository(EmployeeInfoContext context)
        {
            _context = context;
        }
        public async Task<List<EmployeeModel>> GetAllEmployeesAsync() 
        { 
            var records=await _context.Employees.Select(x => new EmployeeModel()
            {
            Id=x.Id,
            Name=x.Name,
            Description=x.Description
            }).ToListAsync();

            return records;
        
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int employeeId)
        {
            var records = await _context.Employees.Where(x=>x.Id==employeeId).Select(x => new EmployeeModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).FirstOrDefaultAsync();

            return records;

        }

        public async Task<int> AddEmployeeAsync(EmployeeModel employeeModel)
        {
            var employee = new Employees()
            {
                Name = employeeModel.Name,
                Description = employeeModel.Description
            };

            _context.Employees.Add(employee);
           await _context.SaveChangesAsync();

            return employee.Id;
        }

        public async Task UpdateEmployeeAsync(int employeeId,EmployeeModel employeeModel)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee != null)
            { 
                employee.Name = employeeModel.Name;
                employee.Description = employeeModel.Description; 
                
                await _context.SaveChangesAsync();
            }

        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            var employee = new Employees() { Id = employeeId };
            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();
        }

    }
}
