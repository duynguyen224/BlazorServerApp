using BlazorServerApp.Common;
using BlazorServerApp.Context;
using BlazorServerApp.Data.DTO.Request;
using BlazorServerApp.Data.Entities;
using BlazorServerApp.Data.Objects;
using System.Runtime.ConstrainedExecution;

namespace BlazorServerApp.Services.Impl
{
    public class DepartmentService : IDepartmentService
    {
        private readonly AppDBContext _dbContext;

        public DepartmentService(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        public async Task<PaginationInfo<Department>> GetPaginatedListAsync(PaginationInfo<Department> paginationInfo)
        {
            var departments = _dbContext.Departments;

            return await PaginationInfo<Department>.CreatePaginatedListAsync(departments, paginationInfo);
        }

        public async Task<Department> FindById(Guid id)
        {
            return await _dbContext.Departments.FindAsync(id);
        }

        public async Task Create(DepartmentCreateRequest department)
        {
            List<Department> list = new List<Department>();
            for(int i= 1; i<=143; i++)
            {
                var d = new Department();
                d.Name = department.Name + i;
                d.Status = department.Status == true ? (int)Constants.Status.Active : (int)Constants.Status.InActive;
                list.Add(d);
            }
            await _dbContext.AddRangeAsync(list);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(DepartmentUpdateRequest department, Guid departmentId)
        {
            var d = await _dbContext.Departments.FindAsync(departmentId);
            if (d != null)
            {
                d.Name = department.Name;
                d.Status = department.Status == true ? (int)Constants.Status.Active : (int)Constants.Status.InActive;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid departmentId)
        {
            var d = await _dbContext.Departments.FindAsync(departmentId);
            if (d != null)
            {
                d.Status = (int)Constants.Status.InActive;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
