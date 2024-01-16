using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApiMovie.Data.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Cart_CustomerCartId",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "CustomerCartId",
                table: "Customer",
                newName: "CustomerCartCartId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_CustomerCartId",
                table: "Customer",
                newName: "IX_Customer_CustomerCartCartId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cart",
                newName: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Cart_CustomerCartCartId",
                table: "Customer",
                column: "CustomerCartCartId",
                principalTable: "Cart",
                principalColumn: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Cart_CustomerCartCartId",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "CustomerCartCartId",
                table: "Customer",
                newName: "CustomerCartId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_CustomerCartCartId",
                table: "Customer",
                newName: "IX_Customer_CustomerCartId");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Cart",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Cart_CustomerCartId",
                table: "Customer",
                column: "CustomerCartId",
                principalTable: "Cart",
                principalColumn: "Id");
        }
    }
}
