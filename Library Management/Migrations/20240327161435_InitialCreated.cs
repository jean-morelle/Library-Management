using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomAuteur = table.Column<string>(name: "Nom_Auteur", type: "nvarchar(max)", nullable: false),
                    AnneeDePublication = table.Column<DateTime>(name: "Annee_De_Publication", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotDePasse = table.Column<string>(name: "Mot_De_Passe", type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreationCompte = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emprunts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDEmpreinte = table.Column<DateTime>(name: "Date_D_Empreinte", type: "datetime2", nullable: false),
                    DateDeRetour = table.Column<DateTime>(name: "Date_De_Retour", type: "datetime2", nullable: true),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprunts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprunts_Utilisateurs_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpruntLivre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpruntId = table.Column<int>(type: "int", nullable: false),
                    LivreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpruntLivre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpruntLivre_Emprunts_EmpruntId",
                        column: x => x.EmpruntId,
                        principalTable: "Emprunts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpruntLivre_Livre_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpruntLivre_EmpruntId",
                table: "EmpruntLivre",
                column: "EmpruntId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpruntLivre_LivreId",
                table: "EmpruntLivre",
                column: "LivreId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprunts_UtilisateurId",
                table: "Emprunts",
                column: "UtilisateurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpruntLivre");

            migrationBuilder.DropTable(
                name: "Emprunts");

            migrationBuilder.DropTable(
                name: "Livre");

            migrationBuilder.DropTable(
                name: "Utilisateurs");
        }
    }
}
