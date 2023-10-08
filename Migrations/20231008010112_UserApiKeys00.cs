using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogLink.Migrations
{
    /// <inheritdoc />
    public partial class UserApiKeys00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserApiKeys");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserApiKeys",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
