using BlazorServerApp.Data.DTO.Request;
using BlazorServerApp.Data.Entities;

namespace BlazorServerApp.Services
{
    public interface IDepartmentService
    {
        public IEnumerable<Department> GetAll();
        public Task<Department> FindById(Guid id);
        public Task Create(DepartmentCreateRequest department);
        public Task Update(DepartmentUpdateRequest department, Guid departmentId);
        public Task Delete(Guid departmentId);
    }
}
