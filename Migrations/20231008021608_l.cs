using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogLink.Migrations
{
    /// <inheritdoc />
    public partial class l : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserApiKeys_AspNetUsers_IdentityUserId",
                table: "UserApiKeys");

            migrationBuilder.DropIndex(
                name: "IX_UserApiKeys_IdentityUserId",
                table: "UserApiKeys");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "UserApiKeys");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserApiKeys",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserApiKeys",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserApiKeys_UserId",
                table: "UserApiKeys",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserApiKeys_AspNetUsers_UserId",
                table: "UserApiKeys",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserApiKeys_AspNetUsers_UserId",
                table: "UserApiKeys");

            migrationBuilder.DropIndex(
                name: "IX_UserApiKeys_UserId",
                table: "UserApiKeys");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserApiKeys");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserApiKeys",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "UserApiKeys",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserApiKeys_IdentityUserId",
                table: "UserApiKeys",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserApiKeys_AspNetUsers_IdentityUserId",
                table: "UserApiKeys",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
