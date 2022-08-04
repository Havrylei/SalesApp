using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgresMigrations.Migrations
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
                    { new Guid("693183bf-51c4-45cd-9d2c-e8fbd20e10c3"), "Сlothes" },
                    { new Guid("eca5013b-9edd-4594-9461-9b5d4f242496"), "Food" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "ImageUrl", "Name", "Price", "StockQty", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("27742995-2510-4a0c-99ac-5423ceeb1b5d"), new Guid("693183bf-51c4-45cd-9d2c-e8fbd20e10c3"), new DateTime(2022, 8, 4, 16, 5, 42, 547, DateTimeKind.Utc).AddTicks(1684), "https://images.unsplash.com/photo-1591047139829-d91aecb6caea?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=436&q=80", "Jacket", 4.00m, 5, new DateTime(2022, 8, 4, 16, 5, 42, 547, DateTimeKind.Utc).AddTicks(1684) },
                    { new Guid("3b3a2147-6848-4cdd-ab95-cf1dcbb68fa9"), new Guid("eca5013b-9edd-4594-9461-9b5d4f242496"), new DateTime(2022, 8, 4, 16, 5, 42, 547, DateTimeKind.Utc).AddTicks(1666), "https://images.unsplash.com/photo-1570145820259-b5b80c5c8bd6?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1074&q=80", "Brownie", 0.65m, 48, new DateTime(2022, 8, 4, 16, 5, 42, 547, DateTimeKind.Utc).AddTicks(1665) },
                    { new Guid("40ae7306-9686-4a28-b716-e28cf05c6eb6"), new Guid("693183bf-51c4-45cd-9d2c-e8fbd20e10c3"), new DateTime(2022, 8, 4, 16, 5, 42, 547, DateTimeKind.Utc).AddTicks(1677), "https://images.unsplash.com/photo-1618354691373-d851c5c3a990?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=415&q=80", "Shirt", 2.00m, 5, new DateTime(2022, 8, 4, 16, 5, 42, 547, DateTimeKind.Utc).AddTicks(1677) },
                    { new Guid("740fe256-ceac-432b-9c59-b6024eb61bd1"), new Guid("eca5013b-9edd-4594-9461-9b5d4f242496"), new DateTime(2022, 8, 4, 16, 5, 42, 547, DateTimeKind.Utc).AddTicks(1674), "https://images.unsplash.com/photo-1595994195534-d5219f02f99f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80", "Water", 1.50m, 30, new DateTime(2022, 8, 4, 16, 5, 42, 547, DateTimeKind.Utc).AddTicks(1674) },
                    { new Guid("b63cb897-34e3-4cec-bd05-1a87dc03521b"), new Guid("eca5013b-9edd-4594-9461-9b5d4f242496"), new DateTime(2022, 8, 4, 16, 5, 42, 547, DateTimeKind.Utc).AddTicks(1669), "https://images.unsplash.com/photo-1607958996333-41aef7caefaa?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80", "Muffin", 1.00m, 36, new DateTime(2022, 8, 4, 16, 5, 42, 547, DateTimeKind.Utc).AddTicks(1669) },
                    { new Guid("b924d25d-ed10-4cab-b594-130685201560"), new Guid("eca5013b-9edd-4594-9461-9b5d4f242496"), new DateTime(2022, 8, 4, 16, 5, 42, 547, DateTimeKind.Utc).AddTicks(1673), "https://images.unsplash.com/photo-1584541305671-af4f46b4be2f?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=965&q=80", "Apple tart", 1.50m, 60, new DateTime(2022, 8, 4, 16, 5, 42, 547, DateTimeKind.Utc).AddTicks(1672) },
                    { new Guid("b962e94b-5e22-407b-a197-907d929b35f8"), new Guid("693183bf-51c4-45cd-9d2c-e8fbd20e10c3"), new DateTime(2022, 8, 4, 16, 5, 42, 547, DateTimeKind.Utc).AddTicks(1679), "https://images.unsplash.com/photo-1542272604-787c3835535d?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1026&q=80", "Pants", 3.00m, 5, new DateTime(2022, 8, 4, 16, 5, 42, 547, DateTimeKind.Utc).AddTicks(1678) },
                    { new Guid("cb0c4d16-e8c1-4ddb-843a-eda45a43b85f"), new Guid("693183bf-51c4-45cd-9d2c-e8fbd20e10c3"), new DateTime(2022, 8, 4, 16, 5, 42, 547, DateTimeKind.Utc).AddTicks(1687), "https://images.unsplash.com/photo-1582845512747-e42001c95638?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80", "Toy", 2.00m, 1, new DateTime(2022, 8, 4, 16, 5, 42, 547, DateTimeKind.Utc).AddTicks(1687) },
                    { new Guid("dd9a61b1-a90b-41f4-bfd3-ca41647b8bf4"), new Guid("eca5013b-9edd-4594-9461-9b5d4f242496"), new DateTime(2022, 8, 4, 16, 5, 42, 547, DateTimeKind.Utc).AddTicks(1671), "https://images.unsplash.com/photo-1553786013-ad9531e591d4?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1135&q=80", "Cake Pop", 1.35m, 24, new DateTime(2022, 8, 4, 16, 5, 42, 547, DateTimeKind.Utc).AddTicks(1671) }
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
