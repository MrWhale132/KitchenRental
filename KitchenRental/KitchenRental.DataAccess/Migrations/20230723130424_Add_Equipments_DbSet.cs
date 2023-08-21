using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitchenRental.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Add_Equipments_DbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentDto_RentalKitchens_RentalKitchenDtoId",
                table: "EquipmentDto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentDto",
                table: "EquipmentDto");

            migrationBuilder.RenameTable(
                name: "EquipmentDto",
                newName: "Equipments");

            migrationBuilder.RenameIndex(
                name: "IX_EquipmentDto_RentalKitchenDtoId",
                table: "Equipments",
                newName: "IX_Equipments_RentalKitchenDtoId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RentalKitchens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RentalKitchens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_RentalKitchens_RentalKitchenDtoId",
                table: "Equipments",
                column: "RentalKitchenDtoId",
                principalTable: "RentalKitchens",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_RentalKitchens_RentalKitchenDtoId",
                table: "Equipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments");

            migrationBuilder.RenameTable(
                name: "Equipments",
                newName: "EquipmentDto");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_RentalKitchenDtoId",
                table: "EquipmentDto",
                newName: "IX_EquipmentDto_RentalKitchenDtoId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RentalKitchens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RentalKitchens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentDto",
                table: "EquipmentDto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentDto_RentalKitchens_RentalKitchenDtoId",
                table: "EquipmentDto",
                column: "RentalKitchenDtoId",
                principalTable: "RentalKitchens",
                principalColumn: "Id");
        }
    }
}
