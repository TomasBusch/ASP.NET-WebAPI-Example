using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixWishlistUserRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishList_AspNetUsers_AppUserId",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_WishList_AppUserId",
                table: "WishList");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "WishList");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "WishList",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WishList_OwnerId",
                table: "WishList",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_AspNetUsers_OwnerId",
                table: "WishList",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishList_AspNetUsers_OwnerId",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_WishList_OwnerId",
                table: "WishList");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "WishList");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "WishList",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishList_AppUserId",
                table: "WishList",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_AspNetUsers_AppUserId",
                table: "WishList",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
