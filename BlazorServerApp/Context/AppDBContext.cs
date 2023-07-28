using BlazorServerApp.Data.Entities;
using BlazorServerApp.Data.Objects;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerApp.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public override int SaveChanges()
        {
            HandleSaveChanges();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            HandleSaveChanges();

            return await base.SaveChangesAsync();
        }

        private void HandleSaveChanges()
        {
            ChangeTracker.DetectChanges();

            var now = DateTime.UtcNow;
            var fakeCurrentUserId = Guid.Parse("2bb693ad-119b-4b8a-95b1-b965de447652");

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is BaseEntity entity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = now;
                            entity.CreatedBy = fakeCurrentUserId;
                            entity.UpdatedDate = now;
                            entity.UpdatedBy = fakeCurrentUserId;
                            break;
                        case EntityState.Modified:
                        case EntityState.Deleted:
                            entity.UpdatedDate = now;
                            entity.UpdatedBy = fakeCurrentUserId;
                            break;
                        case EntityState.Unchanged:
                            break;
                    }
                }
            }
        }
    }
}
