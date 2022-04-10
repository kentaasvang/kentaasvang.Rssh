using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kent.Cli.Rssh.Migrations
{
    public partial class GroupIdonconnectiondetailsmustbenullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionDetails_Groups_GroupId",
                table: "ConnectionDetails");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupId",
                table: "ConnectionDetails",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionDetails_Groups_GroupId",
                table: "ConnectionDetails",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionDetails_Groups_GroupId",
                table: "ConnectionDetails");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupId",
                table: "ConnectionDetails",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionDetails_Groups_GroupId",
                table: "ConnectionDetails",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
