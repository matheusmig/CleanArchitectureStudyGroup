using System;
using Domain.User;
using Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configuration
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("User");

            builder.Property(user => user.Name)
                .HasConversion(
                    valueObject => valueObject.ToString(),
                    valueStr => new Name(valueStr))
                .IsRequired();

            builder.Property(user => user.Birthdate)
                .HasConversion(
                    valueObject => valueObject.DateTime,
                    valueDate => new Birthdate(valueDate));
        }
    }
}
