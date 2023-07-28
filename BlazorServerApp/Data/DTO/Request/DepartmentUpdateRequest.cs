using System.ComponentModel.DataAnnotations;
using BlazorServerApp.Attributes;

namespace BlazorServerApp.Data.DTO.Request
{
    public class DepartmentUpdateRequest
    {
        public Guid Id { get; set; }
        [Required]
        [NotDuplicateName]
        public string Name { get; set; }
        public bool Status { get; set; } = true;
    }
}
