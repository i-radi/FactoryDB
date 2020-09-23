using System.Collections.Generic;
using Factory.Entities.Joins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class RawMaterial
    {
        public int Id { get; set; }

        public int MaterialId { get; set; }
        public double UnitOfMeaeure { get; set; }
        public double StandardCost { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<MaterialOrderJoin> MaterialOrderJoins { get; set; }
    }
    public class RawMaterialConfig : IEntityTypeConfiguration<RawMaterial>
    {
        public void Configure(EntityTypeBuilder<RawMaterial> builder)
        {
            //Table Level
            builder.ToTable("RawMaterials", "Factory");

            // Relationship level
            builder.HasOne(x => x.Category)
                .WithMany(x => x.RawMaterials)
                .HasForeignKey(x => x.CategoryId);

            builder.HasMany(x => x.Orders)
                .WithMany(x => x.RawMaterials)
                .UsingEntity<MaterialOrderJoin>(
                    b => b.HasOne(e => e.Order).WithMany(x => x.MaterialOrderJoins)
                        .HasForeignKey(e => e.OrderId),
                    b => b.HasOne(e => e.RawMaterial).WithMany(x => x.MaterialOrderJoins)
                        .HasForeignKey(e => e.RawMaterialId));
        }
    }

}
