using EmployeeForm.Models;
using Dapper;
using EmployeeForm.Context;
using System.Data;
using EmployeeForm.Dto;
using AutoMapper;

namespace EmployeeForm.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(DapperContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
  
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            var storedProc = "GetEmp";
            //var query = "SELECT first_name as FirstName, last_name as LastName, employee_code as EmployeeCode, contact_no as Contact, dob as DoB, emp_address as Address  FROM Employee";
            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employee>(storedProc, commandType: CommandType.StoredProcedure);
                return employees.ToList();
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync( int id)
        {
            var storedProc = "GetEmpById";

            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QuerySingleAsync<Employee>(storedProc, new { id }, commandType: CommandType.StoredProcedure);
                return employee;
            }
        }

        public async Task<CreateEmployeeDto> CreateEmployeeAsync(Employee employee)
        {
            var storedProc = "CreateEmp";

            var parameters = new DynamicParameters();
            parameters.Add("FirstName", employee.FirstName, DbType.String);
            parameters.Add("LastName", employee.LastName, DbType.String);
            parameters.Add("EmployeeCode", employee.EmployeeCode, DbType.Int32);
            parameters.Add("Contact", employee.Contact, DbType.String);
            parameters.Add("DoB", employee.DoB, DbType.Date);
            parameters.Add("Address", employee.Address, DbType.String);

            int empCode = employee.EmployeeCode;

            if (!await IsEmployeeCodeUnique(empCode))
            {
                throw new InvalidOperationException("Employee Code must be unique.");
            }

            using (var connection = _context.CreateConnection())
            {
                int id = await connection.QuerySingleAsync<int>(storedProc, parameters, commandType: CommandType.StoredProcedure);
                //var createdEmployee = new CreateEmployeeDto { Id = id, FirstName = employee.FirstName, LastName = employee.LastName };

                var createdEmployee = _mapper.Map<CreateEmployeeDto>(employee);
                createdEmployee.Id = id;
                return createdEmployee;
            }
        }

        public async Task<bool> IsEmployeeCodeUnique(int employeeCode)
        {

            var sql = "Select Count(1) from Employee where EmployeeCode = @EmployeeCode";

            var parameters = new DynamicParameters();
            parameters.Add("EmployeeCode", employeeCode, DbType.Int32);
            using (var connection = _context.CreateConnection())
            {
                int count = await connection.QueryFirstOrDefaultAsync<int>(sql, parameters);
                bool empCodeExist = false;
                if(count == 0)
                {
                    empCodeExist = true;
                }
                return empCodeExist;
            }
        }

        public async Task UpdateEmployeeAsync(int id, Employee employee)
        {
            var storedProc = "UpdateEmp";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("FirstName", employee.FirstName, DbType.String);
            parameters.Add("LastName", employee.LastName, DbType.String);
            parameters.Add("EmployeeCode", employee.EmployeeCode, DbType.Int32);
            parameters.Add("Contact", employee.Contact, DbType.String);
            parameters.Add("DoB", employee.DoB, DbType.Date);
            parameters.Add("Address", employee.Address, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(storedProc, parameters, commandType: CommandType.StoredProcedure);
            }

        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var storedProc = "DeleteProc";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(storedProc, new { id });
            }
        }
    } 

}
