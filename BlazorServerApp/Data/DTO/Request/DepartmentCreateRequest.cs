using System.ComponentModel.DataAnnotations;
using BlazorServerApp.Attributes;

namespace BlazorServerApp.Data.DTO.Request
{
    public class DepartmentCreateRequest
    {
        [Required]
        [NotDuplicateName]
        public string Name { get; set; }
        public bool Status { get; set; } = true;
    }
}
