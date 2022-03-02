using Microsoft.EntityFrameworkCore;
using musingo_backend.Configurations;
using musingo_backend.Models;

namespace musingo_backend.Data;

public class RepositoryContext : DbContext
{
    public virtual DbSet<Offer> Offers { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserComment> UserComments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Server=localhost:5432;Database=musingo;User Id=postgres;Password=secretpassword");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<Offer>(new OfferConfiguration());
        modelBuilder.ApplyConfiguration<Transaction>(new TransactionConfiguration());
        modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
        modelBuilder.ApplyConfiguration<UserComment>(new UserCommentConfiguration());
        
    }
    
}