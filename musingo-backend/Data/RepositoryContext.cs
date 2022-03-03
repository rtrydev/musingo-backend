using Microsoft.EntityFrameworkCore;
using musingo_backend.Configurations;
using musingo_backend.Models;
using Microsoft.Extensions.Configuration;

namespace musingo_backend.Data;

public class RepositoryContext : DbContext
{
    public virtual DbSet<Offer> Offers { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserComment> UserComments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=musingo;User ID=sa;Password=superpass123#;Trusted_Connection=False;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<Offer>(new OfferConfiguration());
        modelBuilder.ApplyConfiguration<Transaction>(new TransactionConfiguration());
        modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
        modelBuilder.ApplyConfiguration<UserComment>(new UserCommentConfiguration());
        
    }
    
}