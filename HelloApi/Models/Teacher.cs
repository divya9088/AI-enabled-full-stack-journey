using System.ComponentModel.DataAnnotations;

namespace HelloApi.Models
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
    }
}
