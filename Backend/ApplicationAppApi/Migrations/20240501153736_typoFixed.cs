using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationAppApi.Migrations
{
    /// <inheritdoc />
    public partial class typoFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Applications",
                newName: "startDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Applications",
                newName: "endDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "startDate",
                table: "Applications",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "endDate",
                table: "Applications",
                newName: "EndDate");
        }
    }
}
