using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cantini.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    FId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.FId);
                });

            migrationBuilder.CreateTable(
                name: "FoodItem",
                columns: table => new
                {
                    FId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItem", x => x.FId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    SId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.SId);
                    table.ForeignKey(
                        name: "FK_Student_Faculty_FId",
                        column: x => x.FId,
                        principalTable: "Faculty",
                        principalColumn: "FId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SId = table.Column<int>(type: "int", nullable: false),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OId);
                    table.ForeignKey(
                        name: "FK_Order_Student_SId",
                        column: x => x.SId,
                        principalTable: "Student",
                        principalColumn: "SId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    OId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_FoodItem_FId",
                        column: x => x.FId,
                        principalTable: "FoodItem",
                        principalColumn: "FId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OId",
                        column: x => x.OId,
                        principalTable: "Order",
                        principalColumn: "OId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_SId",
                table: "Order",
                column: "SId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_FId",
                table: "OrderDetail",
                column: "FId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OId",
                table: "OrderDetail",
                column: "OId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_FId",
                table: "Student",
                column: "FId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "FoodItem");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Faculty");
        }
    }
}
