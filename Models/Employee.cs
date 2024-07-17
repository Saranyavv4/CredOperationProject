using System.ComponentModel.DataAnnotations;

namespace ASP.NET_CRUD_Operation.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
