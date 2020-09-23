using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class Storage
    {
        public int Id { get; set; }

        public string Area { get; set; }
        public string Place { get; set; }
        public int InventoryId { get; set; }

        public ICollection<Product> products { get; set; }
        public ICollection<MachinePart> MachineParts { get; set; }
        public ICollection<SensorDataLog> SensorDataLogs { get; set; }
    }
    public class StorageConfig : IEntityTypeConfiguration<Storage>
    {
        public void Configure(EntityTypeBuilder<Storage> builder)
        {
            //Table Level
            builder.ToTable("Storages", "Factory");
        }
    }
}