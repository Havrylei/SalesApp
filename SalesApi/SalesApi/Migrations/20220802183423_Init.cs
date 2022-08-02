using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    StockQty = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Qty = table.Column<int>(type: "integer", nullable: false)
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
                values: new object[,]
                {
                    { new Guid("62c10f43-4ece-48bc-baf3-43a98d7fc25c"), "Сlothes" },
                    { new Guid("b85a72af-2271-4a72-be3d-b805cd63a608"), "Food" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "ImageUrl", "Name", "Price", "StockQty", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("8571fd36-04ad-431d-857d-5f13b9b34baf"), new Guid("62c10f43-4ece-48bc-baf3-43a98d7fc25c"), new DateTime(2022, 8, 2, 18, 34, 23, 269, DateTimeKind.Utc).AddTicks(901), "https://images.unsplash.com/photo-1582845512747-e42001c95638?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80", "Toy", 2.00m, 1, new DateTime(2022, 8, 2, 18, 34, 23, 269, DateTimeKind.Utc).AddTicks(900) },
                    { new Guid("8792fb33-c7f1-40ba-8d9f-518053ee97f0"), new Guid("b85a72af-2271-4a72-be3d-b805cd63a608"), new DateTime(2022, 8, 2, 18, 34, 23, 269, DateTimeKind.Utc).AddTicks(881), "https://images.unsplash.com/photo-1553786013-ad9531e591d4?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1135&q=80", "Cake Pop", 1.35m, 24, new DateTime(2022, 8, 2, 18, 34, 23, 269, DateTimeKind.Utc).AddTicks(880) },
                    { new Guid("a5605979-523b-4702-9a97-429534c77991"), new Guid("62c10f43-4ece-48bc-baf3-43a98d7fc25c"), new DateTime(2022, 8, 2, 18, 34, 23, 269, DateTimeKind.Utc).AddTicks(898), "https://images.unsplash.com/photo-1542272604-787c3835535d?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1026&q=80", "Pants", 3.00m, 5, new DateTime(2022, 8, 2, 18, 34, 23, 269, DateTimeKind.Utc).AddTicks(897) },
                    { new Guid("ad0b5f65-a2d8-4da1-8449-d6336fba19b2"), new Guid("b85a72af-2271-4a72-be3d-b805cd63a608"), new DateTime(2022, 8, 2, 18, 34, 23, 269, DateTimeKind.Utc).AddTicks(895), "https://images.unsplash.com/photo-1595994195534-d5219f02f99f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80", "Water", 1.50m, 30, new DateTime(2022, 8, 2, 18, 34, 23, 269, DateTimeKind.Utc).AddTicks(894) },
                    { new Guid("b80e1ded-c48b-4fa7-a9d8-adebc85f401c"), new Guid("62c10f43-4ece-48bc-baf3-43a98d7fc25c"), new DateTime(2022, 8, 2, 18, 34, 23, 269, DateTimeKind.Utc).AddTicks(899), "https://images.unsplash.com/photo-1591047139829-d91aecb6caea?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=436&q=80", "Jacket", 4.00m, 5, new DateTime(2022, 8, 2, 18, 34, 23, 269, DateTimeKind.Utc).AddTicks(899) },
                    { new Guid("bbd812c6-44bd-474e-932b-3503c64e0f5a"), new Guid("62c10f43-4ece-48bc-baf3-43a98d7fc25c"), new DateTime(2022, 8, 2, 18, 34, 23, 269, DateTimeKind.Utc).AddTicks(896), "https://images.unsplash.com/photo-1618354691373-d851c5c3a990?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=415&q=80", "Shirt", 2.00m, 5, new DateTime(2022, 8, 2, 18, 34, 23, 269, DateTimeKind.Utc).AddTicks(896) },
                    { new Guid("be03c6dc-cb4e-4beb-95b0-c92a3113d054"), new Guid("b85a72af-2271-4a72-be3d-b805cd63a608"), new DateTime(2022, 8, 2, 18, 34, 23, 269, DateTimeKind.Utc).AddTicks(877), "https://images.unsplash.com/photo-1570145820259-b5b80c5c8bd6?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1074&q=80", "Brownie", 0.65m, 48, new DateTime(2022, 8, 2, 18, 34, 23, 269, DateTimeKind.Utc).AddTicks(871) },
                    { new Guid("c08427cd-0b5c-45e8-a4bc-ee09591ac465"), new Guid("b85a72af-2271-4a72-be3d-b805cd63a608"), new DateTime(2022, 8, 2, 18, 34, 23, 269, DateTimeKind.Utc).AddTicks(879), "https://images.unsplash.com/photo-1607958996333-41aef7caefaa?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80", "Muffin", 1.00m, 36, new DateTime(2022, 8, 2, 18, 34, 23, 269, DateTimeKind.Utc).AddTicks(879) },
                    { new Guid("e8b91c0f-9ee6-4f09-9a16-85ad70942350"), new Guid("b85a72af-2271-4a72-be3d-b805cd63a608"), new DateTime(2022, 8, 2, 18, 34, 23, 269, DateTimeKind.Utc).AddTicks(893), "https://images.unsplash.com/photo-1584541305671-af4f46b4be2f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=965&q=80", "Apple tart", 1.50m, 60, new DateTime(2022, 8, 2, 18, 34, 23, 269, DateTimeKind.Utc).AddTicks(893) }
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
