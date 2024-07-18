using EmployeeForm.Dto;
using EmployeeForm.Models;

namespace EmployeeForm.Repository
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        public Task<Employee> GetEmployeeByIdAsync(int id);
        public Task<CreateEmployeeDto> CreateEmployeeAsync(Employee employee);

        public Task DeleteEmployeeAsync(int id);
        public Task UpdateEmployeeAsync(int id, Employee employee);

    }
}
