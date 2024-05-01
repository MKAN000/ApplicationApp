using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationAppApi.Migrations
{
    /// <inheritdoc />
    public partial class DbRedisign4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_SupervisorsOrder_SupervisorModelId",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "SupervisorModelId",
                table: "Applications",
                newName: "SupervisorModelOrderNo");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_SupervisorModelId",
                table: "Applications",
                newName: "IX_Applications_SupervisorModelOrderNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_SupervisorsOrder_SupervisorModelOrderNo",
                table: "Applications",
                column: "SupervisorModelOrderNo",
                principalTable: "SupervisorsOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_SupervisorsOrder_SupervisorModelOrderNo",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "SupervisorModelOrderNo",
                table: "Applications",
                newName: "SupervisorModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_SupervisorModelOrderNo",
                table: "Applications",
                newName: "IX_Applications_SupervisorModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_SupervisorsOrder_SupervisorModelId",
                table: "Applications",
                column: "SupervisorModelId",
                principalTable: "SupervisorsOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
