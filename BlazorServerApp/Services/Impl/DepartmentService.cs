using BlazorServerApp.Common;
using BlazorServerApp.Context;
using BlazorServerApp.Data.DTO.Request;
using BlazorServerApp.Data.Entities;
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
        public IEnumerable<Department> GetAll()
        {
            return from s in _dbContext.Departments
                   select s;
        }

        public async Task<Department> FindById(Guid id)
        {
            return await _dbContext.Departments.FindAsync(id);
        }

        public async Task Create(DepartmentCreateRequest department)
        {
            var d = new Department();
            d.Name = department.Name;
            d.Status = department.Status == true ? (int)Constants.Status.Active : (int)Constants.Status.InActive;
            await _dbContext.AddAsync(d);
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
