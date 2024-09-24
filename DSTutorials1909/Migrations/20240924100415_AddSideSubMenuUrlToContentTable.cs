using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSTutorials1909.Migrations
{
    /// <inheritdoc />
    public partial class AddSideSubMenuUrlToContentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SideSubMenuUrl",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SideSubMenuUrl",
                table: "Contents");
        }
    }
}
