namespace LegalCaseManagement.Data
{
    public class RoleService : GenService<Role>
    {
        public RoleService(ApplicationDbContext context) : base(context)
        {

        }
    }
}
