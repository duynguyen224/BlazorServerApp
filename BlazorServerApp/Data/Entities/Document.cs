using BlazorServerApp.Data.Objects;
using System.ComponentModel.DataAnnotations;

namespace BlazorServerApp.Data.Entities
{
    public class Document : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public byte[] FileData { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
