using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestmentPortal.API.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TB_USER",
                newName: "UserName");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "TB_USER",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "TB_USER");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "TB_USER",
                newName: "Name");
        }
    }
}
