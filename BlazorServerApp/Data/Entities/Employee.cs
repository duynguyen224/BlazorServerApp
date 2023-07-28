using System.ComponentModel.DataAnnotations;
using BlazorServerApp.Data.Objects;

namespace BlazorServerApp.Data.Entities
{
    public class Employee : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Status { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
