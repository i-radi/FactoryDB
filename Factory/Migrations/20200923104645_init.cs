using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Factory.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Factory");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeoLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Garages",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GarageNumber = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lines",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeoLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RawMaterials",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeaeure = table.Column<double>(type: "float", nullable: false),
                    StandardCost = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RawMaterials_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Factory",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostPerHour = table.Column<double>(type: "float", nullable: false),
                    CarNumber = table.Column<int>(type: "int", nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    GarageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Garages_GarageId",
                        column: x => x.GarageId,
                        principalSchema: "Factory",
                        principalTable: "Garages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageCostPerHour = table.Column<double>(type: "float", nullable: false),
                    LineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Machines_Lines_LineId",
                        column: x => x.LineId,
                        principalSchema: "Factory",
                        principalTable: "Lines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftLineJoin",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    LineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftLineJoin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftLineJoin_Lines_LineId",
                        column: x => x.LineId,
                        principalSchema: "Factory",
                        principalTable: "Lines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftLineJoin_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalSchema: "Factory",
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    LineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Factory",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Lines_LineId",
                        column: x => x.LineId,
                        principalSchema: "Factory",
                        principalTable: "Lines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Storages_StorageId",
                        column: x => x.StorageId,
                        principalSchema: "Factory",
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDetial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Cars_CarId",
                        column: x => x.CarId,
                        principalSchema: "Factory",
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Factory",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "Factory",
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SensorId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensors_Cars_CarId",
                        column: x => x.CarId,
                        principalSchema: "Factory",
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDNumber = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Machines_MachineId",
                        column: x => x.MachineId,
                        principalSchema: "Factory",
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalSchema: "Factory",
                        principalTable: "Shifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineParts",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    MaintenanceAge = table.Column<int>(type: "int", nullable: false),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineParts_Cars_CarId",
                        column: x => x.CarId,
                        principalSchema: "Factory",
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineParts_Machines_MachineId",
                        column: x => x.MachineId,
                        principalSchema: "Factory",
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineParts_Storages_StorageId",
                        column: x => x.StorageId,
                        principalSchema: "Factory",
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialOrderJoin",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RawMaterialId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialOrderJoin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialOrderJoin_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Factory",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialOrderJoin_RawMaterials_RawMaterialId",
                        column: x => x.RawMaterialId,
                        principalSchema: "Factory",
                        principalTable: "RawMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SensorDataLogs",
                schema: "Factory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeRead = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SensorId = table.Column<int>(type: "int", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorDataLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorDataLogs_Sensors_SensorId",
                        column: x => x.SensorId,
                        principalSchema: "Factory",
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SensorDataLogs_Storages_StorageId",
                        column: x => x.StorageId,
                        principalSchema: "Factory",
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_GarageId",
                schema: "Factory",
                table: "Cars",
                column: "GarageId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MachineId",
                schema: "Factory",
                table: "Employees",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ShiftId",
                schema: "Factory",
                table: "Employees",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineParts_CarId",
                schema: "Factory",
                table: "MachineParts",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineParts_MachineId",
                schema: "Factory",
                table: "MachineParts",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineParts_StorageId",
                schema: "Factory",
                table: "MachineParts",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_LineId",
                schema: "Factory",
                table: "Machines",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialOrderJoin_OrderId",
                schema: "Factory",
                table: "MaterialOrderJoin",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialOrderJoin_RawMaterialId",
                schema: "Factory",
                table: "MaterialOrderJoin",
                column: "RawMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarId",
                schema: "Factory",
                table: "Orders",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                schema: "Factory",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SupplierId",
                schema: "Factory",
                table: "Orders",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                schema: "Factory",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LineId",
                schema: "Factory",
                table: "Products",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StorageId",
                schema: "Factory",
                table: "Products",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_RawMaterials_CategoryId",
                schema: "Factory",
                table: "RawMaterials",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorDataLogs_SensorId",
                schema: "Factory",
                table: "SensorDataLogs",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorDataLogs_StorageId",
                schema: "Factory",
                table: "SensorDataLogs",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_CarId",
                schema: "Factory",
                table: "Sensors",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftLineJoin_LineId",
                schema: "Factory",
                table: "ShiftLineJoin",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftLineJoin_ShiftId",
                schema: "Factory",
                table: "ShiftLineJoin",
                column: "ShiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees",
                schema: "Factory");

            migrationBuilder.DropTable(
                name: "MachineParts",
                schema: "Factory");

            migrationBuilder.DropTable(
                name: "MaterialOrderJoin",
                schema: "Factory");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Factory");

            migrationBuilder.DropTable(
                name: "SensorDataLogs",
                schema: "Factory");

            migrationBuilder.DropTable(
                name: "ShiftLineJoin",
                schema: "Factory");

            migrationBuilder.DropTable(
                name: "Machines",
                schema: "Factory");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Factory");

            migrationBuilder.DropTable(
                name: "RawMaterials",
                schema: "Factory");

            migrationBuilder.DropTable(
                name: "Sensors",
                schema: "Factory");

            migrationBuilder.DropTable(
                name: "Storages",
                schema: "Factory");

            migrationBuilder.DropTable(
                name: "Shifts",
                schema: "Factory");

            migrationBuilder.DropTable(
                name: "Lines",
                schema: "Factory");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Factory");

            migrationBuilder.DropTable(
                name: "Suppliers",
                schema: "Factory");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "Factory");

            migrationBuilder.DropTable(
                name: "Cars",
                schema: "Factory");

            migrationBuilder.DropTable(
                name: "Garages",
                schema: "Factory");
        }
    }
}
