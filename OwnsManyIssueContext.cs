using Microsoft.EntityFrameworkCore;
using OwnsManyIssue.Aggregates;
using OwnsManyIssue.Configurations;

namespace OwnsManyIssue
{
    public class OwnsManyIssueContext : DbContext
    {
        public DbSet<Aggregate> Aggregates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=OwnsManyIssueDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AggregateTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}