using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationAppApi.Migrations
{
    /// <inheritdoc />
    public partial class Supp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Applicants_ApplicantModelAlbumNumber",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_SupervisorsOrder_SupervisorModelOrderNo",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ApplicantModelAlbumNumber",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_SupervisorModelOrderNo",
                table: "Applications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicantModelAlbumNumber",
                table: "Applications",
                column: "ApplicantModelAlbumNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_SupervisorModelOrderNo",
                table: "Applications",
                column: "SupervisorModelOrderNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Applicants_ApplicantModelAlbumNumber",
                table: "Applications",
                column: "ApplicantModelAlbumNumber",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_SupervisorsOrder_SupervisorModelOrderNo",
                table: "Applications",
                column: "SupervisorModelOrderNo",
                principalTable: "SupervisorsOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
