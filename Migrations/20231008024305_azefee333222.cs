using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogLink.Migrations
{
    /// <inheritdoc />
    public partial class azefee333222 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserApiKeys_AspNetUsers_Id",
                table: "UserApiKeys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserApiKeys",
                table: "UserApiKeys");

            migrationBuilder.DropIndex(
                name: "IX_UserApiKeys_Id",
                table: "UserApiKeys");

            migrationBuilder.DropColumn(
                name: "ApiKeyId",
                table: "UserApiKeys");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserApiKeys",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "UserApiKeys",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserApiKeys",
                table: "UserApiKeys",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserApiKeys_UserID",
                table: "UserApiKeys",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserApiKeys_AspNetUsers_UserID",
                table: "UserApiKeys",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserApiKeys_AspNetUsers_UserID",
                table: "UserApiKeys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserApiKeys",
                table: "UserApiKeys");

            migrationBuilder.DropIndex(
                name: "IX_UserApiKeys_UserID",
                table: "UserApiKeys");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "UserApiKeys");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "UserApiKeys",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "ApiKeyId",
                table: "UserApiKeys",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserApiKeys",
                table: "UserApiKeys",
                column: "ApiKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserApiKeys_Id",
                table: "UserApiKeys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserApiKeys_AspNetUsers_Id",
                table: "UserApiKeys",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
