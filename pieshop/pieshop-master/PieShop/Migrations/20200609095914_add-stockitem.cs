using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PieShop.Migrations
{
    public partial class addstockitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Cakes_CakeId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Pies_PieId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Cakes_CakeId",
                table: "ShoppingCartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Pies_PieId",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_CakeId",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_PieId",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_CakeId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_PieId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "CakeId",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "PieId",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "CakeId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "PieId",
                table: "OrderDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "stockitemid",
                table: "ShoppingCartItems",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "stockitemId",
                table: "OrderDetails",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "stockItems",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stockItems", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_stockitemid",
                table: "ShoppingCartItems",
                column: "stockitemid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_stockitemId",
                table: "OrderDetails",
                column: "stockitemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_stockItems_stockitemId",
                table: "OrderDetails",
                column: "stockitemId",
                principalTable: "stockItems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_stockItems_stockitemid",
                table: "ShoppingCartItems",
                column: "stockitemid",
                principalTable: "stockItems",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_stockItems_stockitemId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_stockItems_stockitemid",
                table: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "stockItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_stockitemid",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_stockitemId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "stockitemid",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "stockitemId",
                table: "OrderDetails");

            migrationBuilder.AddColumn<Guid>(
                name: "CakeId",
                table: "ShoppingCartItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PieId",
                table: "ShoppingCartItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CakeId",
                table: "OrderDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PieId",
                table: "OrderDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_CakeId",
                table: "ShoppingCartItems",
                column: "CakeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_PieId",
                table: "ShoppingCartItems",
                column: "PieId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CakeId",
                table: "OrderDetails",
                column: "CakeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_PieId",
                table: "OrderDetails",
                column: "PieId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Cakes_CakeId",
                table: "OrderDetails",
                column: "CakeId",
                principalTable: "Cakes",
                principalColumn: "CakeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Pies_PieId",
                table: "OrderDetails",
                column: "PieId",
                principalTable: "Pies",
                principalColumn: "PieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Cakes_CakeId",
                table: "ShoppingCartItems",
                column: "CakeId",
                principalTable: "Cakes",
                principalColumn: "CakeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Pies_PieId",
                table: "ShoppingCartItems",
                column: "PieId",
                principalTable: "Pies",
                principalColumn: "PieId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
