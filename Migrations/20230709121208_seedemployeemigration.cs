using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kudvenkitPractice.Migrations
{
    /// <inheritdoc />
    public partial class seedemployeemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Gender", "Name" },
                values: new object[] { 1, 6, "umair.tahir@gmail.com", 0, "Umair" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
