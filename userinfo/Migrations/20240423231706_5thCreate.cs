using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace userinfo.Migrations
{
    /// <inheritdoc />
    public partial class _5thCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Garages",
                columns: table => new
                {
                    vehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    vin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modelYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    engineCylinders = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    displacementL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    engineHP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    driveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mileage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    purchaseDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.vehicleId);
                });

            migrationBuilder.CreateTable(
                name: "Servicelogs",
                columns: table => new
                {
                    servicelogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    mileageIn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mileageOut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serviceNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicelogs", x => x.servicelogId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Garages");

            migrationBuilder.DropTable(
                name: "Servicelogs");
        }
    }
}
