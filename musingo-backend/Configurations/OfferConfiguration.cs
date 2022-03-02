using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using musingo_backend.Models;

namespace musingo_backend.Configurations;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.ToTable("offers")
            .HasOne(x => x.Owner)
            .WithMany()
            .IsRequired()
            .HasForeignKey("owner_id");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Title)
            .HasColumnName("title")
            .HasColumnType("text")
            .IsRequired();
        
        builder.Property(x => x.ImageUrl)
            .HasColumnName("image_url")
            .HasColumnType("text")
            .IsRequired();
        
        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasColumnType("text")
            .IsRequired();
        
        builder.Property(x => x.OfferStatus)
            .HasColumnName("offer_status")
            .HasColumnType("int")
            .IsRequired();
    }
}