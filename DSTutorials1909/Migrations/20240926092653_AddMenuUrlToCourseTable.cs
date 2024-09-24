using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSTutorials1909.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuUrlToCourseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MenuUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuUrl",
                table: "Courses");
        }
    }
}
