using BlazorServerApp.Common;
using BlazorServerApp.Context;
using BlazorServerApp.Data.DTO.Request;
using BlazorServerApp.Data.Entities;
using BlazorServerApp.Data.Objects;
using System.Runtime.ConstrainedExecution;

namespace BlazorServerApp.Services.Impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDBContext _dbContext;

        public EmployeeService(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        public async Task<PaginationInfo<Employee>> GetPaginatedListAsync(PaginationInfo<Employee> paginationInfo)
        {
            var employees = _dbContext.Employees;

            return await PaginationInfo<Employee>.CreatePaginatedListAsync(employees, paginationInfo);
        }

        public async Task<Employee> FindById(Guid id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }

        public async Task Create(EmployeeCreateRequest employee)
        {
            var e = new Employee();
            e.Name = employee.Name;
            e.Status = employee.Status == true ? (int)Constants.Status.Active : (int)Constants.Status.InActive;
            await _dbContext.AddAsync(e);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(EmployeeUpdateRequest employee, Guid employeeId)
        {
            var e = await _dbContext.Employees.FindAsync(employeeId);
            if (e != null)
            {
                e.Name = employee.Name;
                e.Status = employee.Status == true ? (int)Constants.Status.Active : (int)Constants.Status.InActive;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid employeeId)
        {
            var e = await _dbContext.Employees.FindAsync(employeeId);
            if (e != null)
            {
                e.Status = (int)Constants.Status.InActive;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
