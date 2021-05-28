using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class CourseBaseViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}