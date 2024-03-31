using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationAppApi.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationModelExtended2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationPuprose",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ToWhom",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationPuprose",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ToWhom",
                table: "Applications");
        }
    }
}
