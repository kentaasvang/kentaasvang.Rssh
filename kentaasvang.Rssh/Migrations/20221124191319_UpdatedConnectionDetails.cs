using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kentaasvang.Rssh.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedConnectionDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConnectionDetails_Groups_GroupId",
                table: "ConnectionDetails");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConnectionDetails",
                table: "ConnectionDetails");

            migrationBuilder.DropIndex(
                name: "IX_ConnectionDetails_GroupId",
                table: "ConnectionDetails");

            migrationBuilder.DropColumn(
                name: "ConnectionName",
                table: "ConnectionDetails");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "ConnectionDetails");

            migrationBuilder.RenameTable(
                name: "ConnectionDetails",
                newName: "connection_detail");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "connection_detail",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "connection_detail",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Ip",
                table: "connection_detail",
                newName: "ip");

            migrationBuilder.RenameColumn(
                name: "ConnectionDetailId",
                table: "connection_detail",
                newName: "name");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "connection_detail",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "connection_detail",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ip",
                table: "connection_detail",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "connection_detail",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_connection_detail",
                table: "connection_detail",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_connection_detail",
                table: "connection_detail");

            migrationBuilder.DropColumn(
                name: "id",
                table: "connection_detail");

            migrationBuilder.RenameTable(
                name: "connection_detail",
                newName: "ConnectionDetails");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "ConnectionDetails",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "ConnectionDetails",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "ip",
                table: "ConnectionDetails",
                newName: "Ip");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ConnectionDetails",
                newName: "ConnectionDetailId");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "ConnectionDetails",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "ConnectionDetails",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Ip",
                table: "ConnectionDetails",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "ConnectionName",
                table: "ConnectionDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                table: "ConnectionDetails",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConnectionDetails",
                table: "ConnectionDetails",
                column: "ConnectionDetailId");

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionDetails_GroupId",
                table: "ConnectionDetails",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConnectionDetails_Groups_GroupId",
                table: "ConnectionDetails",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }
    }
}
