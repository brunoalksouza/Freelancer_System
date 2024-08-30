using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataEF.Configurations;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.HasDiscriminator<UserRole>("Role")
            .HasValue<Professional>(UserRole.PROFESSIONAL)
            .HasValue<Client>(UserRole.CLIENT);

        builder.Property(x => x.CPF)
            .IsRequired()
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);


        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.CPF).IsUnique();
        builder.Property(x => x.PasswordHash)
            .HasColumnType("text").IsRequired();
    }
}