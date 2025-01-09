using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pintxos.Data.Migrations
{
    public partial class AddPintxo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pintxos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ContestId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OwnerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OwnerId1 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pintxos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pintxos_AspNetUsers_OwnerId1",
                        column: x => x.OwnerId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pintxos_Contests_ContestId",
                        column: x => x.ContestId,
                        principalTable: "Contests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pintxos_ContestId",
                table: "Pintxos",
                column: "ContestId");

            migrationBuilder.CreateIndex(
                name: "IX_Pintxos_OwnerId1",
                table: "Pintxos",
                column: "OwnerId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pintxos");
        }
    }
}
