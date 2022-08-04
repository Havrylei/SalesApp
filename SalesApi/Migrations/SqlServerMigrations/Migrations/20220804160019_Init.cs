using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlServerMigrations.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQty = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("83ccab3c-8501-4f54-a28c-96b81d43d73c"), "Food" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("cde42a15-9e97-4cde-969f-7bb0836c6585"), "Сlothes" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "ImageUrl", "Name", "Price", "StockQty", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("21973832-ac20-498a-b6b6-798360e850e4"), new Guid("83ccab3c-8501-4f54-a28c-96b81d43d73c"), new DateTime(2022, 8, 4, 16, 0, 19, 477, DateTimeKind.Utc).AddTicks(7366), "https://images.unsplash.com/photo-1595994195534-d5219f02f99f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80", "Water", 1.50m, 30, new DateTime(2022, 8, 4, 16, 0, 19, 477, DateTimeKind.Utc).AddTicks(7365) },
                    { new Guid("4400a395-45b4-4d6e-976f-34d7f81a3a5b"), new Guid("cde42a15-9e97-4cde-969f-7bb0836c6585"), new DateTime(2022, 8, 4, 16, 0, 19, 477, DateTimeKind.Utc).AddTicks(7373), "https://images.unsplash.com/photo-1591047139829-d91aecb6caea?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=436&q=80", "Jacket", 4.00m, 5, new DateTime(2022, 8, 4, 16, 0, 19, 477, DateTimeKind.Utc).AddTicks(7373) },
                    { new Guid("70c977fb-0745-4bfa-a24b-331c2030a5eb"), new Guid("83ccab3c-8501-4f54-a28c-96b81d43d73c"), new DateTime(2022, 8, 4, 16, 0, 19, 477, DateTimeKind.Utc).AddTicks(7330), "https://images.unsplash.com/photo-1570145820259-b5b80c5c8bd6?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1074&q=80", "Brownie", 0.65m, 48, new DateTime(2022, 8, 4, 16, 0, 19, 477, DateTimeKind.Utc).AddTicks(7329) },
                    { new Guid("74da4602-a7a4-4930-b68a-dd149ec63550"), new Guid("83ccab3c-8501-4f54-a28c-96b81d43d73c"), new DateTime(2022, 8, 4, 16, 0, 19, 477, DateTimeKind.Utc).AddTicks(7334), "https://images.unsplash.com/photo-1553786013-ad9531e591d4?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1135&q=80", "Cake Pop", 1.35m, 24, new DateTime(2022, 8, 4, 16, 0, 19, 477, DateTimeKind.Utc).AddTicks(7333) },
                    { new Guid("79e9df11-2897-44fa-9a92-92947da0363d"), new Guid("cde42a15-9e97-4cde-969f-7bb0836c6585"), new DateTime(2022, 8, 4, 16, 0, 19, 477, DateTimeKind.Utc).AddTicks(7367), "https://images.unsplash.com/photo-1618354691373-d851c5c3a990?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=415&q=80", "Shirt", 2.00m, 5, new DateTime(2022, 8, 4, 16, 0, 19, 477, DateTimeKind.Utc).AddTicks(7367) },
                    { new Guid("8b92fcd7-bee2-4cf8-abe6-c3717465728a"), new Guid("cde42a15-9e97-4cde-969f-7bb0836c6585"), new DateTime(2022, 8, 4, 16, 0, 19, 477, DateTimeKind.Utc).AddTicks(7372), "https://images.unsplash.com/photo-1542272604-787c3835535d?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1026&q=80", "Pants", 3.00m, 5, new DateTime(2022, 8, 4, 16, 0, 19, 477, DateTimeKind.Utc).AddTicks(7372) },
                    { new Guid("8c3ccd57-d4a8-4ada-a213-b61aeba5680a"), new Guid("83ccab3c-8501-4f54-a28c-96b81d43d73c"), new DateTime(2022, 8, 4, 16, 0, 19, 477, DateTimeKind.Utc).AddTicks(7335), "https://images.unsplash.com/photo-1584541305671-af4f46b4be2f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=965&q=80", "Apple tart", 1.50m, 60, new DateTime(2022, 8, 4, 16, 0, 19, 477, DateTimeKind.Utc).AddTicks(7335) },
                    { new Guid("a65b30f7-9836-4483-9eb2-06e6ba858f2d"), new Guid("83ccab3c-8501-4f54-a28c-96b81d43d73c"), new DateTime(2022, 8, 4, 16, 0, 19, 477, DateTimeKind.Utc).AddTicks(7332), "https://images.unsplash.com/photo-1607958996333-41aef7caefaa?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80", "Muffin", 1.00m, 36, new DateTime(2022, 8, 4, 16, 0, 19, 477, DateTimeKind.Utc).AddTicks(7332) },
                    { new Guid("e5dfae3f-c140-41c5-994d-737f8413b68f"), new Guid("cde42a15-9e97-4cde-969f-7bb0836c6585"), new DateTime(2022, 8, 4, 16, 0, 19, 477, DateTimeKind.Utc).AddTicks(7375), "https://images.unsplash.com/photo-1582845512747-e42001c95638?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80", "Toy", 2.00m, 1, new DateTime(2022, 8, 4, 16, 0, 19, 477, DateTimeKind.Utc).AddTicks(7375) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
