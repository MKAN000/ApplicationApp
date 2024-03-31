using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationAppApi.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationModelExtended : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CsvData",
                table: "Applications",
                newName: "arrears");

            migrationBuilder.AddColumn<string>(
                name: "DateRange",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsHavingClasses",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHavingDisciplinaryPenalty",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnDuty",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VacDestination",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRange",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "IsHavingClasses",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "IsHavingDisciplinaryPenalty",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "IsOnDuty",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "VacDestination",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "arrears",
                table: "Applications",
                newName: "CsvData");
        }
    }
}
