using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RetroMarket.Migrations
{
    public partial class ModificationCommentaires : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuteurId",
                table: "Commentaires",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commentaires_AuteurId",
                table: "Commentaires",
                column: "AuteurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaires_AspNetUsers_AuteurId",
                table: "Commentaires",
                column: "AuteurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commentaires_AspNetUsers_AuteurId",
                table: "Commentaires");

            migrationBuilder.DropIndex(
                name: "IX_Commentaires_AuteurId",
                table: "Commentaires");

            migrationBuilder.DropColumn(
                name: "AuteurId",
                table: "Commentaires");
        }
    }
}
