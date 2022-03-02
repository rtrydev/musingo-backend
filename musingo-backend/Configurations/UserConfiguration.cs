using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using musingo_backend.Models;

namespace musingo_backend.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType("int")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType("text")
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasColumnType("text")
            .IsRequired();

        builder.Property(x => x.Password)
            .HasColumnName("password")
            .HasColumnType("text")
            .IsRequired();

        builder.Property(x => x.ImageUrl)
            .HasColumnName("image_url")
            .HasColumnType("text")
            .IsRequired(false);
    }
}