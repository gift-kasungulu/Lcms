namespace LegalCaseManagement.Data.LegalServices
{
    public class CaseStatusService : GenService<CaseStatus>
    {
        public CaseStatusService(ApplicationDbContext context) : base(context)
        {

        }
    }
}
