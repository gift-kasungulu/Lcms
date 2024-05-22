using System.ComponentModel.DataAnnotations;

namespace LegalCaseManagement.Data
{
    public class User
    {
       
        public string id { get; set; } 

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string LoginName { get; set; } = string.Empty;

       
        [Required(ErrorMessage = "Phone number is required")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string LoginPassword { get; set; } = string.Empty;

        public string FirstNameUser { get; set; } = string.Empty;
        public string LastNameUser { get; set; } = string.Empty;
        //public string Gender { get; set; } = string.Empty;
        public string AddressUser { get; set; } = string.Empty;
        public string CountryUser { get; set; } = string.Empty;
        public string CityUser { get; set; } = string.Empty;

        public string UserRole { get; set; } = string.Empty;
    }
}
