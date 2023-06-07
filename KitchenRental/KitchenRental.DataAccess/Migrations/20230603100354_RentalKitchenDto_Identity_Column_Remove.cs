using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitchenRental.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RentalKitchenDto_Identity_Column_Remove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RentalKitchens",
                table: "RentalKitchens");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RentalKitchens");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RentalKitchens");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RentalKitchens",
                table: "RentalKitchens",
                column: "Temporary_Id");
        }
    }
}
