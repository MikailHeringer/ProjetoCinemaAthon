using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoCinemaAthon.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CadastroAtor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaisNascimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoArtista = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroAtor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CadastroGenero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroGenero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrarFilme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diretor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkCapa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrarFilme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VinculoFilmeAtor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrarFilmeId = table.Column<int>(type: "int", nullable: false),
                    CadastroAtorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinculoFilmeAtor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VinculoFilmeAtor_CadastroAtor_CadastroAtorId",
                        column: x => x.CadastroAtorId,
                        principalTable: "CadastroAtor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VinculoFilmeAtor_RegistrarFilme_RegistrarFilmeId",
                        column: x => x.RegistrarFilmeId,
                        principalTable: "RegistrarFilme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VinculoFilmeGenero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrarFilmeId = table.Column<int>(type: "int", nullable: false),
                    CadastroGeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinculoFilmeGenero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VinculoFilmeGenero_CadastroGenero_CadastroGeneroId",
                        column: x => x.CadastroGeneroId,
                        principalTable: "CadastroGenero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VinculoFilmeGenero_RegistrarFilme_RegistrarFilmeId",
                        column: x => x.RegistrarFilmeId,
                        principalTable: "RegistrarFilme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VinculoFilmeAtor_CadastroAtorId",
                table: "VinculoFilmeAtor",
                column: "CadastroAtorId");

            migrationBuilder.CreateIndex(
                name: "IX_VinculoFilmeAtor_RegistrarFilmeId",
                table: "VinculoFilmeAtor",
                column: "RegistrarFilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_VinculoFilmeGenero_CadastroGeneroId",
                table: "VinculoFilmeGenero",
                column: "CadastroGeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_VinculoFilmeGenero_RegistrarFilmeId",
                table: "VinculoFilmeGenero",
                column: "RegistrarFilmeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VinculoFilmeAtor");

            migrationBuilder.DropTable(
                name: "VinculoFilmeGenero");

            migrationBuilder.DropTable(
                name: "CadastroAtor");

            migrationBuilder.DropTable(
                name: "CadastroGenero");

            migrationBuilder.DropTable(
                name: "RegistrarFilme");
        }
    }
}
