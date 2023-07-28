using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerApp.Data.Objects
{
    public class BaseEntity
    {
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
