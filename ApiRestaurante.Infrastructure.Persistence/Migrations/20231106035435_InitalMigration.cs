using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiRestaurante.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DishCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishCategory", x => x.Id);
                });

            migrationBuilder.InsertData(
         table: "DishCategory",
         columns: new[] { "CategoryName" },
         values: new object[,]
         {
                { "Entrada" },
                { "Plato Fuerte" },
                { "Postre" },
                { "Bebida" }
         });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameState = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderState", x => x.Id);
                });

            migrationBuilder.InsertData(
          table: "OrderState",
          columns: new[] { "NameState" },
          values: new object[,]
          {
                { "Proceso" },
                { "Completada" }              
          });

            migrationBuilder.CreateTable(
                name: "TableState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameState = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableState", x => x.Id);
                });

            migrationBuilder.InsertData(
          table: "TableState",
          columns: new[] { "NameState" },
          values: new object[,]
          {
                { "Disponible" },
                { "En proceso de Atención" },
                { "Atendida" }
          });


            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PeopleAmount = table.Column<int>(type: "int", nullable: false),
                    DishCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dishes_DishCategory_DishCategoryId",
                        column: x => x.DishCategoryId,
                        principalTable: "DishCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeopleAmount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tables_TableState_StateId",
                        column: x => x.StateId,
                        principalTable: "TableState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishIngredients",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    IngredientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredients", x => new { x.DishId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_DishIngredients_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishIngredients_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    DishesId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<double>(type: "float", nullable: false),
                    TablesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Dishes_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderState_StateId",
                        column: x => x.StateId,
                        principalTable: "OrderState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Tables_TablesId",
                        column: x => x.TablesId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_DishCategoryId",
                table: "Dishes",
                column: "DishCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_IngredientsId",
                table: "DishIngredients",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DishesId",
                table: "Orders",
                column: "DishesId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StateId",
                table: "Orders",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TablesId",
                table: "Orders",
                column: "TablesId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_StateId",
                table: "Tables",
                column: "StateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishIngredients");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "OrderState");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "DishCategory");

            migrationBuilder.DropTable(
                name: "TableState");
        }
    }
}
