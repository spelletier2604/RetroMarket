using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RetroMarket.Migrations
{
    public partial class InfosProduits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Etat",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TypeProduitID",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    AdresseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodePostal = table.Column<string>(nullable: false),
                    NoCivic = table.Column<int>(nullable: false),
                    NoTelephone = table.Column<string>(nullable: false),
                    Province_Etat = table.Column<string>(nullable: false),
                    Rue = table.Column<string>(nullable: false),
                    Ville = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.AdresseID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategorieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategorieID);
                });

            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    CommentaireID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Corps = table.Column<string>(nullable: false),
                    Note = table.Column<int>(nullable: false),
                    Titre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.CommentaireID);
                });

            migrationBuilder.CreateTable(
                name: "Compagnies",
                columns: table => new
                {
                    CompagnieID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(nullable: false),
                    Pays = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compagnies", x => x.CompagnieID);
                });

            migrationBuilder.CreateTable(
                name: "TypesProduit",
                columns: table => new
                {
                    TypeProduitID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategorieID = table.Column<int>(nullable: false),
                    CompagnieID = table.Column<int>(nullable: true),
                    Nom = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesProduit", x => x.TypeProduitID);
                    table.ForeignKey(
                        name: "FK_TypesProduit_Categories_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categories",
                        principalColumn: "CategorieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypesProduit_Compagnies_CompagnieID",
                        column: x => x.CompagnieID,
                        principalTable: "Compagnies",
                        principalColumn: "CompagnieID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeProduitID",
                table: "Products",
                column: "TypeProduitID");

            migrationBuilder.CreateIndex(
                name: "IX_TypesProduit_CategorieID",
                table: "TypesProduit",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_TypesProduit_CompagnieID",
                table: "TypesProduit",
                column: "CompagnieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_TypesProduit_TypeProduitID",
                table: "Products",
                column: "TypeProduitID",
                principalTable: "TypesProduit",
                principalColumn: "TypeProduitID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_TypesProduit_TypeProduitID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "TypesProduit");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Compagnies");

            migrationBuilder.DropIndex(
                name: "IX_Products_TypeProduitID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Etat",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TypeProduitID",
                table: "Products");
        }
    }
}
