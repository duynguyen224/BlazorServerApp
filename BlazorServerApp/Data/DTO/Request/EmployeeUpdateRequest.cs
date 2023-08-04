using System.ComponentModel.DataAnnotations;

namespace BlazorServerApp.Data.DTO.Request
{
    public class EmployeeUpdateRequest
    {
        public Guid Id { get; set; }
        [Required]
        //[NotDuplicateName]
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
