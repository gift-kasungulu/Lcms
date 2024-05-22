namespace LegalCaseManagement.Data
{
    public class LawyerService : GenService<Lawyers>
    {
        public LawyerService(ApplicationDbContext context) : base(context)
        {

        }
    }
}
