
using LegalCaseManagement.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<CaseDocument> Documents { get; set; }
        public DbSet<MyCaseWonOrLost> MyCaseWonOrLost { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Explicitly exclude System.Threading.Tasks.Task
            builder.Ignore<System.Threading.Tasks.Task>();

            builder.Entity<MyTask>()
                .HasOne(t => t.Case)
                .WithMany() // Assuming there's no collection navigation property in Case for MyTask
                .HasForeignKey(t => t.CaseId)
                .OnDelete(DeleteBehavior.Cascade); // Specify Delete cascade action

            //builder.Entity<Lawyers>()
            //    .HasKey l => l.Id)
                
            //    .OnDelete(DeleteBehavior.Cascade); // tryinh to forcely cascade a delete ont the lawyer
                

            builder.Entity<MyTask>()
                .HasOne(t => t.LawyerInfo)
                .WithMany() 
                .HasForeignKey(t => t.LawyerId)
                .OnDelete(DeleteBehavior.Cascade); // tondelete every principle Entity that is been traced by dbcontext EFCore

            builder.Entity<Appointment>()
               .HasOne(a => a.User)
               .WithMany(u => u.Appointments)
               .HasForeignKey(a => a.UserId);

            builder.Entity<Notification>()
                .HasKey(n => n.Id);

           

            builder.Entity<Case>()
                .HasMany(c => c.CaseDocuments)
                .WithOne(d => d.Case)
                .HasForeignKey(d => d.CaseId);

            builder.Entity<Case>()
                .HasMany(c => c.Tasks)
                .WithOne(t => t.Case)
                .HasForeignKey(t => t.CaseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Case>()
                .HasMany(c => c.CaseDocuments)
                .WithOne(d => d.Case)
                .HasForeignKey(d => d.CaseId)
                .OnDelete(DeleteBehavior.Cascade);

           


            // Example of configuring other foreign key constraints
            builder.Entity<Case>()
                .HasOne(c => c.WonOrLost)
                .WithMany()
                .HasForeignKey(c => c.WonLostId)
                .OnDelete(DeleteBehavior.Cascade); // Use Cascade if needed or Restrict

            // Configure other relationships
            builder.Entity<Case>()
                .HasOne(c => c.AppUser)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);


        }

    }
}
