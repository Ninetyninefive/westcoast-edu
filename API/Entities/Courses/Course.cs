using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Course", Schema = "Courses")]
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Retired { get; set; }
    }
}