namespace LegalCaseManagement.Data
{
    public class CaseService : GenService<Case>
    {
        public CaseService(ApplicationDbContext context) : base(context)
        {

        }
    }
}
