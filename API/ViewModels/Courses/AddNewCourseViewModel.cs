using System.ComponentModel.DataAnnotations;
namespace API.ViewModels
{
    public class AddNewCourseViewModel
    {

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}