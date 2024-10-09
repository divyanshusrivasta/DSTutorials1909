using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSTutorials1909.Migrations
{
    /// <inheritdoc />
    public partial class AddCascadeDeleteSolution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Solutions_QId",
                table: "Solutions",
                column: "QId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solutions_Questions_QId",
                table: "Solutions",
                column: "QId",
                principalTable: "Questions",
                principalColumn: "QId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solutions_Questions_QId",
                table: "Solutions");

            migrationBuilder.DropIndex(
                name: "IX_Solutions_QId",
                table: "Solutions");
        }
    }
}
