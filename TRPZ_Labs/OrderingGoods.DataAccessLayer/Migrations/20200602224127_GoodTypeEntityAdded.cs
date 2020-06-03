using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderingGoods.DataAccessLayer.Implementation.Migrations
{
    public partial class GoodTypeEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Goods");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Goods",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GoodTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GoodTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Стіл" },
                    { 2, "Шафа" },
                    { 3, "Футболка" },
                    { 4, "Шорти" },
                    { 5, "Кросівки" },
                    { 6, "Пральна машина" },
                    { 7, "Мікрохвильова піч" },
                    { 8, "Ноутбук" },
                    { 9, "Телефон" },
                    { 10, "Фотоапарат" }
                });

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 1,
                column: "TypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 2,
                column: "TypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 3,
                column: "TypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 4,
                column: "TypeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 5,
                column: "TypeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 6,
                column: "TypeId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 7,
                column: "TypeId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 8,
                column: "TypeId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 9,
                column: "TypeId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 10,
                column: "TypeId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 11,
                column: "TypeId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 12,
                column: "TypeId",
                value: 10);

            migrationBuilder.CreateIndex(
                name: "IX_Goods_TypeId",
                table: "Goods",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goods_GoodTypes_TypeId",
                table: "Goods",
                column: "TypeId",
                principalTable: "GoodTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goods_GoodTypes_TypeId",
                table: "Goods");

            migrationBuilder.DropTable(
                name: "GoodTypes");

            migrationBuilder.DropIndex(
                name: "IX_Goods_TypeId",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Goods");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Goods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Стіл");

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Шафа");

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Футболка");

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Шорти");

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Кросівки");

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Пральна машина");

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Мікрохвильова піч");

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Ноутбук");

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Телефон");

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Телефон");

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 11,
                column: "Name",
                value: "Телефон");

            migrationBuilder.UpdateData(
                table: "Goods",
                keyColumn: "Id",
                keyValue: 12,
                column: "Name",
                value: "Фотоапарат");
        }
    }
}
