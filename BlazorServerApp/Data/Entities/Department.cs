using System.ComponentModel.DataAnnotations;
using BlazorServerApp.Data.Objects;

namespace BlazorServerApp.Data.Entities
{
    public class Department : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
    }
}
