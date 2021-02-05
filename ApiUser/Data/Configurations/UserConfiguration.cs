﻿using ApiUser.Data.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiUser.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Name).HasMaxLength(50).IsRequired();
            builder.Property(m => m.Surname).HasMaxLength(50).IsRequired();
            builder.Property(m => m.Email).HasMaxLength(50).IsRequired();
            builder.Property(m => m.Token).HasMaxLength(100);
            builder.Property(m => m.Password).HasMaxLength(100).IsRequired();
            builder.ToTable("Users");
        }
    }
}
