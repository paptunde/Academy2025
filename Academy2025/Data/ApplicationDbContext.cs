using Microsoft.EntityFrameworkCore;

namespace Academy2025.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
               
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Author)
                .WithMany(u => u.AuthoredCourses)
                .HasForeignKey(c => c.AuthorId);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}