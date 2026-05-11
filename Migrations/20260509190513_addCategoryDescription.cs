using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalabatSmartVillage.Migrations
{
    /// <inheritdoc />
    public partial class addCategoryDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Quick and easy meals");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Cheesy and delicious");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Japanese delicacy");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Juicy and filling");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Tender and tasty");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "Fresh from the ocean");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Sweet and indulgent");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Nutritious and balanced");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "category");
        }
    }
}
