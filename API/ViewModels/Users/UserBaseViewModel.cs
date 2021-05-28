using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class UserBaseViewModel
    {
        [Required]
        public string Email { get; set; }
    }
}