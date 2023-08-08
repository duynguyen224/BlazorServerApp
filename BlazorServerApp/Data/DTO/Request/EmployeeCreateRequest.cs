using System.ComponentModel.DataAnnotations;

namespace BlazorServerApp.Data.DTO.Request
{
    public class EmployeeCreateRequest
    {
        [Required]
        //[NotDuplicateName]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public bool Status { get; set; } = true;
    }
}
