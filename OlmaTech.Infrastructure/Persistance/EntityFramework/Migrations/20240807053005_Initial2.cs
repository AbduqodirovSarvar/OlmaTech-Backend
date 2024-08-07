using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlmaTech.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubitleEn",
                table: "HomePosts",
                newName: "SubtitleEn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubtitleEn",
                table: "HomePosts",
                newName: "SubitleEn");
        }
    }
}
