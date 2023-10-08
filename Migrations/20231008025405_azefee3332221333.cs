using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogLink.Migrations
{
    /// <inheritdoc />
    public partial class azefee3332221333 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserApiKeys_AspNetUsers_UserID",
                table: "UserApiKeys");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "UserApiKeys",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserApiKeys_UserID",
                table: "UserApiKeys",
                newName: "IX_UserApiKeys_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserApiKeys",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_UserApiKeys_AspNetUsers_UserId",
                table: "UserApiKeys",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserApiKeys_AspNetUsers_UserId",
                table: "UserApiKeys");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserApiKeys",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserApiKeys_UserId",
                table: "UserApiKeys",
                newName: "IX_UserApiKeys_UserID");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "UserApiKeys",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserApiKeys_AspNetUsers_UserID",
                table: "UserApiKeys",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
