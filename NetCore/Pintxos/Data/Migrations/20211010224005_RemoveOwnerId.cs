using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pintxos.Data.Migrations
{
    public partial class RemoveOwnerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pintxos_AspNetUsers_OwnerId1",
                table: "Pintxos");

            migrationBuilder.DropIndex(
                name: "IX_Pintxos_OwnerId1",
                table: "Pintxos");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Pintxos");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Pintxos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Pintxos_OwnerId",
                table: "Pintxos",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pintxos_AspNetUsers_OwnerId",
                table: "Pintxos",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pintxos_AspNetUsers_OwnerId",
                table: "Pintxos");

            migrationBuilder.DropIndex(
                name: "IX_Pintxos_OwnerId",
                table: "Pintxos");

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Pintxos",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "Pintxos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pintxos_OwnerId1",
                table: "Pintxos",
                column: "OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pintxos_AspNetUsers_OwnerId1",
                table: "Pintxos",
                column: "OwnerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
