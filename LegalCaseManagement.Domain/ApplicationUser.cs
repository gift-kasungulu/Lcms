using LegalCaseManagement.Domain;
using Microsoft.AspNetCore.Identity;

namespace LegalCaseManagement.Data
{
    public class ApplicationUser : IdentityUser
    {
      
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        // Navigation properties
        public List<Case> Cases = new List<Case>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<Notification> Notifications { get; set; }
       
        


    }
}
