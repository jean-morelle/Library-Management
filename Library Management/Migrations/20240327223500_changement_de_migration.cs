using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class changementdemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpruntLivre");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_D_Empreinte",
                table: "Emprunts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_D_Empreinte",
                table: "Emprunts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
        }
    }
}
