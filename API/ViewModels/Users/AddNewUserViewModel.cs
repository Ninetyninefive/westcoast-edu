using System.ComponentModel.DataAnnotations;
namespace API.ViewModels
{
    public class AddNewUserViewModel : UserBaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}