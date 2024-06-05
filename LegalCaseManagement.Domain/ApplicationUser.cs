using Microsoft.AspNetCore.Identity;

namespace LegalCaseManagement.Data
{
    public class ApplicationUser : IdentityUser
    {
        // Removed the UserId property because IdentityUser already has an Id property
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        // Navigation property
        public List<Case> Cases = new List<Case>();

        

    }
}
