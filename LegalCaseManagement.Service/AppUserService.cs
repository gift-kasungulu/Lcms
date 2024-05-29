namespace LegalCaseManagement.Data
{
    public class AppUserService : GenService<ApplicationUser>
    {
        public AppUserService(ApplicationDbContext myDbContext) : base(myDbContext)
        {

        }
    }
}
