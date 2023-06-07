using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitchenRental.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RentalKitchenDto_Identity_Column_Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.AddColumn<int>(
			   name: "Id",
			   table: "RentalKitchens",
               defaultValue: 0);
            
			migrationBuilder.AddPrimaryKey(
				name: "PK_RentalKitchens",
				table: "RentalKitchens",
				column: "Id");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
