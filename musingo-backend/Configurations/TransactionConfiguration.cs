using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using musingo_backend.Models;

namespace musingo_backend.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("transactions")
            .HasOne(x => x.Buyer);
        builder.ToTable("transactions")
            .HasOne(x => x.Seller);
        builder.ToTable("transactions")
            .HasOne(x => x.Offer);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Status)
            .HasColumnName("status")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(x => x.LastUpdateTime)
            .HasColumnName("last_update_time")
            .HasColumnType("timestamp")
            .IsRequired();

    }
}