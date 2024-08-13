using CompanyRelationship.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CompanyRelationship.Data
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<BranchOffice> BranchOffices { get; set; }
        public DbSet<BranchOfficeDept> BranchOfficeDepts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Company>()
                .HasIndex(c => c.Name)
                .IsUnique();
            // Configure the Company entity
            modelBuilder.Entity<Company>()
                .HasKey(c => c.Name);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Parents)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the BranchOffice entity
            modelBuilder.Entity<BranchOffice>()
                .HasKey(b => b.Name);

            modelBuilder.Entity<BranchOffice>()
                .HasMany(b => b.Children)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            // Configure the BranchOfficeDept entity
            modelBuilder.Entity<BranchOfficeDept>()
                .HasKey(d => d.Name);

        }
    }

}
