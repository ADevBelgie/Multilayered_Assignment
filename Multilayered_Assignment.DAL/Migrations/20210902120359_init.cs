using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Multilayered_Assignment.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginViewModel",
                columns: table => new
                {
                    LoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingBagId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RememberLogin = table.Column<bool>(type: "bit", nullable: false),
                    ReturnUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginViewModel", x => x.LoginId);
                    table.UniqueConstraint("AK_LoginViewModel_UserName", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "ProductTShirtViewModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TshirtRegistrationNumer = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTShirtViewModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingBagViewModel",
                columns: table => new
                {
                    ShoppingBagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginId = table.Column<int>(type: "int", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingBagViewModel", x => x.ShoppingBagId);
                    table.ForeignKey(
                        name: "FK_ShoppingBagViewModel_LoginViewModel_LoginId",
                        column: x => x.LoginId,
                        principalTable: "LoginViewModel",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingItemViewModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingBagId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingItemViewModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShoppingItemViewModel_ProductTShirtViewModel_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductTShirtViewModel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingItemViewModel_ShoppingBagViewModel_ShoppingBagId",
                        column: x => x.ShoppingBagId,
                        principalTable: "ShoppingBagViewModel",
                        principalColumn: "ShoppingBagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LoginViewModel",
                columns: new[] { "LoginId", "Password", "RememberLogin", "ReturnUrl", "Role", "ShoppingBagId", "UserName" },
                values: new object[,]
                {
                    { 1, "admin", false, null, "admin", 0, "admin1" },
                    { 2, "arthur", false, null, "normal", 0, "arthur" }
                });

            migrationBuilder.InsertData(
                table: "ProductTShirtViewModel",
                columns: new[] { "ID", "Name", "Picture", "Price", "TshirtRegistrationNumer" },
                values: new object[,]
                {
                    { 50, "Plain Shirt", "plain-shirt.jpg", 1999.0, null },
                    { 49, "Tom&Jerry Shirt", "Tom-Jerry-shirt.jpg", 1999.0, null },
                    { 48, "King Shirt", "king-shirt.jpg", 1999.0, null },
                    { 47, "Xmas Shirt", "christmas-shirt.jpg", 302.0, null },
                    { 46, "Red Shirt", "red-shirt.jpg", 502.0, null },
                    { 45, "Plain Shirt", "plain-shirt.jpg", 1999.0, null },
                    { 44, "Tom&Jerry Shirt", "Tom-Jerry-shirt.jpg", 1999.0, null },
                    { 43, "King Shirt", "king-shirt.jpg", 1999.0, null },
                    { 42, "Xmas Shirt", "christmas-shirt.jpg", 302.0, null },
                    { 41, "Red Shirt", "red-shirt.jpg", 502.0, null },
                    { 40, "Plain Shirt", "plain-shirt.jpg", 1999.0, null },
                    { 39, "Tom&Jerry Shirt", "Tom-Jerry-shirt.jpg", 1999.0, null },
                    { 38, "King Shirt", "king-shirt.jpg", 1999.0, null },
                    { 37, "Xmas Shirt", "christmas-shirt.jpg", 302.0, null },
                    { 51, "Red Shirt", "red-shirt.jpg", 502.0, null },
                    { 52, "Xmas Shirt", "christmas-shirt.jpg", 302.0, null },
                    { 53, "King Shirt", "king-shirt.jpg", 1999.0, null },
                    { 54, "Tom&Jerry Shirt", "Tom-Jerry-shirt.jpg", 1999.0, null },
                    { 68, "King Shirt", "king-shirt.jpg", 1999.0, null },
                    { 67, "Xmas Shirt", "christmas-shirt.jpg", 302.0, null },
                    { 66, "Red Shirt", "red-shirt.jpg", 502.0, null },
                    { 65, "Plain Shirt", "plain-shirt.jpg", 1999.0, null },
                    { 64, "Tom&Jerry Shirt", "Tom-Jerry-shirt.jpg", 1999.0, null },
                    { 63, "King Shirt", "king-shirt.jpg", 1999.0, null },
                    { 36, "Red Shirt", "red-shirt.jpg", 502.0, null },
                    { 62, "Xmas Shirt", "christmas-shirt.jpg", 302.0, null },
                    { 60, "Plain Shirt", "plain-shirt.jpg", 1999.0, null },
                    { 59, "Tom&Jerry Shirt", "Tom-Jerry-shirt.jpg", 1999.0, null },
                    { 58, "King Shirt", "king-shirt.jpg", 1999.0, null },
                    { 57, "Xmas Shirt", "christmas-shirt.jpg", 302.0, null },
                    { 56, "Red Shirt", "red-shirt.jpg", 502.0, null },
                    { 55, "Plain Shirt", "plain-shirt.jpg", 1999.0, null },
                    { 61, "Red Shirt", "red-shirt.jpg", 502.0, null },
                    { 35, "Plain Shirt", "plain-shirt.jpg", 1999.0, null },
                    { 34, "Tom&Jerry Shirt", "Tom-Jerry-shirt.jpg", 1999.0, null },
                    { 33, "King Shirt", "king-shirt.jpg", 1999.0, null },
                    { 14, "Tom&Jerry Shirt", "Tom-Jerry-shirt.jpg", 1999.0, null },
                    { 13, "King Shirt", "king-shirt.jpg", 1999.0, null },
                    { 12, "Xmas Shirt", "christmas-shirt.jpg", 302.0, null },
                    { 11, "Red Shirt", "red-shirt.jpg", 502.0, null }
                });

            migrationBuilder.InsertData(
                table: "ProductTShirtViewModel",
                columns: new[] { "ID", "Name", "Picture", "Price", "TshirtRegistrationNumer" },
                values: new object[,]
                {
                    { 10, "Plain Shirt", "plain-shirt.jpg", 1999.0, null },
                    { 9, "Tom&Jerry Shirt", "Tom-Jerry-shirt.jpg", 1999.0, null },
                    { 15, "Plain Shirt", "plain-shirt.jpg", 1999.0, null },
                    { 8, "King Shirt", "king-shirt.jpg", 1999.0, null },
                    { 6, "Red Shirt", "red-shirt.jpg", 502.0, null },
                    { 5, "Plain Shirt", "plain-shirt.jpg", 1999.0, null },
                    { 4, "Tom&Jerry Shirt", "Tom-Jerry-shirt.jpg", 1999.0, null },
                    { 3, "King Shirt", "king-shirt.jpg", 1999.0, null },
                    { 2, "Xmas Shirt", "christmas-shirt.jpg", 302.0, null },
                    { 1, "Red Shirt", "red-shirt.jpg", 502.0, null },
                    { 7, "Xmas Shirt", "christmas-shirt.jpg", 302.0, null },
                    { 69, "Tom&Jerry Shirt", "Tom-Jerry-shirt.jpg", 1999.0, null },
                    { 16, "Red Shirt", "red-shirt.jpg", 502.0, null },
                    { 18, "King Shirt", "king-shirt.jpg", 1999.0, null },
                    { 32, "Xmas Shirt", "christmas-shirt.jpg", 302.0, null },
                    { 31, "Red Shirt", "red-shirt.jpg", 502.0, null },
                    { 30, "Plain Shirt", "plain-shirt.jpg", 1999.0, null },
                    { 29, "Tom&Jerry Shirt", "Tom-Jerry-shirt.jpg", 1999.0, null },
                    { 28, "King Shirt", "king-shirt.jpg", 1999.0, null },
                    { 27, "Xmas Shirt", "christmas-shirt.jpg", 302.0, null },
                    { 17, "Xmas Shirt", "christmas-shirt.jpg", 302.0, null },
                    { 26, "Red Shirt", "red-shirt.jpg", 502.0, null },
                    { 24, "Tom&Jerry Shirt", "Tom-Jerry-shirt.jpg", 1999.0, null },
                    { 23, "King Shirt", "king-shirt.jpg", 1999.0, null },
                    { 22, "Xmas Shirt", "christmas-shirt.jpg", 302.0, null },
                    { 21, "Red Shirt", "red-shirt.jpg", 502.0, null },
                    { 20, "Plain Shirt", "plain-shirt.jpg", 1999.0, null },
                    { 19, "Tom&Jerry Shirt", "Tom-Jerry-shirt.jpg", 1999.0, null },
                    { 25, "Plain Shirt", "plain-shirt.jpg", 1999.0, null },
                    { 70, "Plain Shirt", "plain-shirt.jpg", 1999.0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBagViewModel_LoginId",
                table: "ShoppingBagViewModel",
                column: "LoginId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingItemViewModel_ProductId",
                table: "ShoppingItemViewModel",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingItemViewModel_ShoppingBagId",
                table: "ShoppingItemViewModel",
                column: "ShoppingBagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingItemViewModel");

            migrationBuilder.DropTable(
                name: "ProductTShirtViewModel");

            migrationBuilder.DropTable(
                name: "ShoppingBagViewModel");

            migrationBuilder.DropTable(
                name: "LoginViewModel");
        }
    }
}
