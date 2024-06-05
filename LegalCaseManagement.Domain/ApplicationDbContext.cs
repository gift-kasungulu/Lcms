
using LegalCaseManagement.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LegalCaseManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Case> Cases { get; set; }
        public DbSet<Lawyers> Lawyers { get; set; }
        public DbSet<CaseType> CaseType { get; set; }
        public DbSet<CaseStatus> CaseStatus { get; set; }
        public DbSet<Priority> PriorityLevel { get; set; }
        public DbSet<MyTaskStatus> Statuses { get; set; }
        public DbSet<MyTask> MyTasks { get; set; }

        


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Explicitly exclude System.Threading.Tasks.Task
            builder.Ignore<System.Threading.Tasks.Task>();

           
        }

    }
}
