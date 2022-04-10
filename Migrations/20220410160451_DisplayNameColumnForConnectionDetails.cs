using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kent.Cli.Rssh.Migrations
{
    public partial class DisplayNameColumnForConnectionDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConnectionName",
                table: "ConnectionDetails",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionName",
                table: "ConnectionDetails");
        }
    }
}
