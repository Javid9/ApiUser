using ApiUser.Data.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUser.Data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();


            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);


            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);


            builder
                .Property(x => x.Amount)
                .HasColumnName("money")
                .IsRequired();


            builder
                .Property(x => x.Desc)
                .HasMaxLength(500);


            builder.ToTable("Transactions");
        }
    }
}
