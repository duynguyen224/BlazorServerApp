using BlazorServerApp.Data.DTO.Request;
using BlazorServerApp.Data.Entities;
using BlazorServerApp.Data.Objects;

namespace BlazorServerApp.Services
{
    public interface IDepartmentService
    {
        public Task<PaginationInfo<Department>> GetPaginatedListAsync(PaginationInfo<Department> paginationData);
        public Task<Department> FindById(Guid id);
        public Task Create(DepartmentCreateRequest department);
        public Task Update(DepartmentUpdateRequest department, Guid departmentId);
        public Task Delete(Guid departmentId);
    }
}
