using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitchenRental.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Add_Equipment_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Equipments",
                table: "RentalKitchens");

            migrationBuilder.CreateTable(
                name: "EquipmentDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RentalKitchenDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentDto_RentalKitchens_RentalKitchenDtoId",
                        column: x => x.RentalKitchenDtoId,
                        principalTable: "RentalKitchens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentDto_RentalKitchenDtoId",
                table: "EquipmentDto",
                column: "RentalKitchenDtoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentDto");

            migrationBuilder.AddColumn<string>(
                name: "Equipments",
                table: "RentalKitchens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
