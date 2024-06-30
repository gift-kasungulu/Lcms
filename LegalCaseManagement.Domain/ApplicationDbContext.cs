
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
        public DbSet<Message> Messages { get; set; }
        public DbSet<CaseDocument> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Explicitly exclude System.Threading.Tasks.Task
            builder.Ignore<System.Threading.Tasks.Task>();

            builder.Entity<MyTask>()
                .HasOne(t => t.Case)
                .WithMany() // Assuming there's no collection navigation property in Case for MyTask
                .HasForeignKey(t => t.CaseId)
                .OnDelete(DeleteBehavior.Restrict); // Specify Restrict or NoAction

            builder.Entity<MyTask>()
                .HasOne(t => t.LawyerInfo)
                .WithMany() // Assuming there's no collection navigation property in Lawyers for MyTask
                .HasForeignKey(t => t.LawyerId)
                .OnDelete(DeleteBehavior.Restrict); // Specify Restrict or NoAction

            builder.Entity<Appointment>()
               .HasOne(a => a.User)
               .WithMany(u => u.Appointments)
               .HasForeignKey(a => a.UserId);

            builder.Entity<Notification>()
                .HasKey(n => n.Id);

            builder.Entity<Notification>()
                .HasOne<ApplicationUser>(n => n.Recipient)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasKey(m => m.Id);

            builder.Entity<Message>()
                .HasOne<ApplicationUser>(m => m.Sender)
                .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Case>()
                .HasMany(c => c.CaseDocuments)
                .WithOne(d => d.Case)
                .HasForeignKey(d => d.CaseId);
        }

    }
}
