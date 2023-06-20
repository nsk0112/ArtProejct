using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtProject.Migrations
{
    /// <inheritdoc />
    public partial class newtable5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExhTable",
                table: "UserExhTable");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "UserExhTable",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "RecId",
                table: "UserExhTable",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExhTable",
                table: "UserExhTable",
                column: "RecId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserExhTable",
                table: "UserExhTable");

            migrationBuilder.DropColumn(
                name: "RecId",
                table: "UserExhTable");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "UserExhTable",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserExhTable",
                table: "UserExhTable",
                column: "Username");
        }
    }
}
