using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cantini.Database.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Faculty_FId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropIndex(
                name: "IX_Student_FId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "FId",
                table: "Student");

            migrationBuilder.AddColumn<string>(
                name: "Faculty",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "FId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Student_FId",
                table: "Student",
                column: "FId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Faculty_FId",
                table: "Student",
                column: "FId",
                principalTable: "Faculty",
                principalColumn: "FId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
