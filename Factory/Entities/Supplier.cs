using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class Supplier
    {
        public string GeoLocation { get; set; }
        public int Id { get; set; }
        public string Phone { get; set; }

        public ICollection<Order> Orders { get; set; }


    }
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            //Table Level
            builder.ToTable("Suppliers", "Factory");
        }
    }
}
