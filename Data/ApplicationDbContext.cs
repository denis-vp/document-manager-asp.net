using document_manager_asp.net.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace document_manager_asp.net.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog = document-manager; Integrated Security = True; Encrypt=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Document>(document =>
            {
                document.Property(d => d.Id).ValueGeneratedOnAdd();
                document.HasKey(d => d.Id);
                document.Property(d => d.Title).IsRequired();
                document.Property(d => d.Author).IsRequired();
                document.Property(d => d.NumPages).IsRequired();
                document.Property(d => d.Type).IsRequired();
                document.Property(d => d.Format).IsRequired();
            });
        }
    }
}
