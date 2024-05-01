using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationAppApi.Migrations
{
    /// <inheritdoc />
    public partial class DbRedisign3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Applicants_ApplicantModelId",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "ApplicantModelId",
                table: "Applications",
                newName: "ApplicantModelAlbumNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_ApplicantModelId",
                table: "Applications",
                newName: "IX_Applications_ApplicantModelAlbumNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Applicants_ApplicantModelAlbumNumber",
                table: "Applications",
                column: "ApplicantModelAlbumNumber",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Applicants_ApplicantModelAlbumNumber",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "ApplicantModelAlbumNumber",
                table: "Applications",
                newName: "ApplicantModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_ApplicantModelAlbumNumber",
                table: "Applications",
                newName: "IX_Applications_ApplicantModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Applicants_ApplicantModelId",
                table: "Applications",
                column: "ApplicantModelId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
