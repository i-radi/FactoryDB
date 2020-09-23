using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public int SerialNumber { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int StorageId { get; set; }
        public Storage Storage { get; set; }
        public int LineId { get; set; }
        public Line Line { get; set; }
    }
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //Table Level
            builder.ToTable("Products", "Factory");

            // Relationship level
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Storage)
                .WithMany(x => x.products)
                .HasForeignKey(x => x.StorageId);

            builder.HasOne(x => x.Line)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.LineId);
        }
    }
}
