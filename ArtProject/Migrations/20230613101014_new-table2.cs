using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtProject.Migrations
{
    /// <inheritdoc />
    public partial class newtable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TableUnitMaster",
                table: "TableUnitMaster");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "TableUnitMaster",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TableUnitMaster",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TableUnitMaster",
                table: "TableUnitMaster",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserExhTable",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExhId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExhTable", x => x.Username);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserExhTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TableUnitMaster",
                table: "TableUnitMaster");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TableUnitMaster");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "TableUnitMaster",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TableUnitMaster",
                table: "TableUnitMaster",
                column: "Username");
        }
    }
}
