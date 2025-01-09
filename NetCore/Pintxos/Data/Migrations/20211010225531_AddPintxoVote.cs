using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pintxos.Data.Migrations
{
    public partial class AddPintxoVote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PintxoVotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PintxoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VoterId = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PintxoVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PintxoVotes_AspNetUsers_VoterId",
                        column: x => x.VoterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PintxoVotes_Pintxos_PintxoId",
                        column: x => x.PintxoId,
                        principalTable: "Pintxos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PintxoVotes_PintxoId",
                table: "PintxoVotes",
                column: "PintxoId");

            migrationBuilder.CreateIndex(
                name: "IX_PintxoVotes_VoterId",
                table: "PintxoVotes",
                column: "VoterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PintxoVotes");
        }
    }
}
