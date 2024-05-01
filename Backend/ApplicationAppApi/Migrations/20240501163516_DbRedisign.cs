using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationAppApi.Migrations
{
    /// <inheritdoc />
    public partial class DbRedisign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicantModelId",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupervisorModelId",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicantModelId",
                table: "Applications",
                column: "ApplicantModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_SupervisorModelId",
                table: "Applications",
                column: "SupervisorModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Applicants_ApplicantModelId",
                table: "Applications",
                column: "ApplicantModelId",
                principalTable: "Applicants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_SupervisorsOrder_SupervisorModelId",
                table: "Applications",
                column: "SupervisorModelId",
                principalTable: "SupervisorsOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Applicants_ApplicantModelId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_SupervisorsOrder_SupervisorModelId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ApplicantModelId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_SupervisorModelId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ApplicantModelId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "SupervisorModelId",
                table: "Applications");
        }
    }
}
