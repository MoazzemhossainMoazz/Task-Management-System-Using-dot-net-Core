using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement1.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Contact { get; set; }
        public string? PicturePath { get; set; }
        [NotMapped]
        public IFormFile Picture { get; set; }
    }
}
