using BlazorServerApp.Data.DTO.Request;
using BlazorServerApp.Data.Entities;
using BlazorServerApp.Data.Objects;

namespace BlazorServerApp.Services
{
    public interface IEmployeeService
    {
        public Task<PaginationInfo<Employee>> GetPaginatedListAsync(PaginationInfo<Employee> paginationData);
        public Task<Employee> FindById(Guid id);
        public Task Create(EmployeeCreateRequest employee);
        public Task Update(EmployeeUpdateRequest employee, Guid departmentId);
        public Task Delete(Guid employeeId);
    }
}
