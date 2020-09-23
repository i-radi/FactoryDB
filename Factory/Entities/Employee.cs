using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Factory.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public double Salary { get; set; }
        public string Type { get; set; }
        public int IDNumber { get; set; }

        public int ShiftId { get; set; }
        public Shift Shift { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
    }

    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //Table Level
            builder.ToTable("Employees", "Factory");

            // Relationship level
            builder.HasOne(x => x.Shift)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.ShiftId);

            builder.HasOne(x => x.Machine)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.MachineId);

        }
    }

}
