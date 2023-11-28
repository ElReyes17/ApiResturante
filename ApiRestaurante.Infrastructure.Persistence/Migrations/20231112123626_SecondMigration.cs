using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRestaurante.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Dishes_DishesId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tables_TablesId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DishesId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TablesId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DishesId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TablesId",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "DishOrders",
                columns: table => new
                {
                    DishesId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishOrders", x => new { x.DishesId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_DishOrders_Dishes_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishOrders_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableId",
                table: "Orders",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_DishOrders_OrdersId",
                table: "DishOrders",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "DishOrders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TableId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "DishesId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TablesId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DishesId",
                table: "Orders",
                column: "DishesId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TablesId",
                table: "Orders",
                column: "TablesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Dishes_DishesId",
                table: "Orders",
                column: "DishesId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tables_TablesId",
                table: "Orders",
                column: "TablesId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
