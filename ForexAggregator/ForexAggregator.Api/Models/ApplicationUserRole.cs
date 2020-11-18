using System.ComponentModel.DataAnnotations;

namespace ForexAggregator.Api.Models
{
    public class ApplicationUserRole
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
