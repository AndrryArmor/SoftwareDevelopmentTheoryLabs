using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderingGoods.DataAccessLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodId = table.Column<int>(nullable: false),
                    ShopId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Goods_GoodId",
                        column: x => x.GoodId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Term = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "Description", "Manufacturer", "Model", "Name" },
                values: new object[,]
                {
                    { 1, "Дерев'яний дубовий стіл з шухлядками", "Київмеблі", "Вікторія", "Стіл" },
                    { 12, "Фотоапарат з 30х зумом, 50 режимами налаштувань і автофокусом", "Nikon", "300X", "Фотоапарат" },
                    { 11, "Смартфон з діагоналлю 6,22', 8-ядерним процесором Snapdragon 632, NFC і IRDA", "Xiaomi", "Redmi Note 8T", "Телефон" },
                    { 10, "Смартфон з діагоналлю 5,7', 4-ядерним процесором MediaTek 231 і сканером відбитків пальців", "Xiaomi", "Redmi Note 7A", "Телефон" },
                    { 8, "Ноутбук чорного кольору з діагоналлю 15', 8-ядерним процесором Intel Core i7 і відеокартою nVidia GeForce", "HP", "ProBook 4540s", "Ноутбук" },
                    { 7, "Мікрохвильова піч з 35 режимами роботи 74х43х50", "LG", "Profy", "Мікрохвильова піч" },
                    { 9, "Смартфон з діагоналлю 6,22', 8-ядерним процесором Snapdragon 632 і NFC", "Samsung", "Galaxy S10", "Телефон" },
                    { 5, "Білі кросівки 37 розміру", "Reebok", null, "Кросівки" },
                    { 4, "Червоні шорти розміру L з зображеннями пальм", "Хмельницький ринок", null, "Шорти" },
                    { 3, "Блакитна футболка розміру XS з принтом в стилі аніме", "Versacci", null, "Футболка" },
                    { 2, "Дерев'яна соснова шафа-купе", "Київмеблі", "Сергій", "Шафа" },
                    { 6, "Пральна машина з горизонтальним завантаженням 134х109х65", "Kaiser", "HT3001", "Пральна машина" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Second hand" },
                    { 1, "TechCenter" },
                    { 2, "Eldorado" },
                    { 3, "Furniture House" },
                    { 5, "1000 things" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "GoodId", "Price", "ShopId" },
                values: new object[,]
                {
                    { 1, 8, 999.89999999999998, 1 },
                    { 16, 5, 25.649999999999999, 5 },
                    { 15, 1, 40.200000000000003, 5 },
                    { 14, 5, 44.119999999999997, 4 },
                    { 13, 4, 5.7400000000000002, 4 },
                    { 12, 3, 10.119999999999999, 4 },
                    { 11, 2, 209.0, 3 },
                    { 10, 1, 36.25, 3 },
                    { 9, 7, 63.539999999999999, 2 },
                    { 8, 6, 345.0, 2 },
                    { 7, 10, 325.5, 2 },
                    { 6, 9, 400.0, 2 },
                    { 5, 8, 1099.9000000000001, 2 },
                    { 4, 11, 624.42999999999995, 1 },
                    { 3, 10, 325.5, 1 },
                    { 2, 9, 450.0, 1 },
                    { 17, 8, 899.89999999999998, 5 },
                    { 18, 10, 300.60000000000002, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_GoodId",
                table: "Items",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShopId",
                table: "Items",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ItemId",
                table: "Orders",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
