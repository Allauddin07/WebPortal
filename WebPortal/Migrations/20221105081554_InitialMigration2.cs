using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPortal.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_AspNetUsers_usersId1",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_usersId1",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "usersId1",
                table: "orders");

            migrationBuilder.AlterColumn<string>(
                name: "usersId",
                table: "orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_orders_usersId",
                table: "orders",
                column: "usersId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_AspNetUsers_usersId",
                table: "orders",
                column: "usersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_AspNetUsers_usersId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_usersId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "usersId",
                table: "orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usersId1",
                table: "orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_usersId1",
                table: "orders",
                column: "usersId1");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_AspNetUsers_usersId1",
                table: "orders",
                column: "usersId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
