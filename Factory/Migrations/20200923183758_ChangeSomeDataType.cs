using Microsoft.EntityFrameworkCore.Migrations;

namespace Factory.Migrations
{
    public partial class ChangeSomeDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitOfMeaeure",
                schema: "Factory",
                table: "RawMaterials");

            migrationBuilder.AlterColumn<string>(
                name: "Area",
                schema: "Factory",
                table: "Storages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "UnitOfMeasure",
                schema: "Factory",
                table: "RawMaterials",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitOfMeasure",
                schema: "Factory",
                table: "RawMaterials");

            migrationBuilder.AlterColumn<double>(
                name: "Area",
                schema: "Factory",
                table: "Storages",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UnitOfMeaeure",
                schema: "Factory",
                table: "RawMaterials",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
