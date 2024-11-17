using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoCinemaAthon.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtorPersonagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VinculoAtorPersonagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePersonagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrarFilmeId = table.Column<int>(type: "int", nullable: false),
                    CadastroAtorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinculoAtorPersonagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VinculoAtorPersonagem_CadastroAtor_CadastroAtorId",
                        column: x => x.CadastroAtorId,
                        principalTable: "CadastroAtor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VinculoAtorPersonagem_RegistrarFilme_RegistrarFilmeId",
                        column: x => x.RegistrarFilmeId,
                        principalTable: "RegistrarFilme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VinculoAtorPersonagem_CadastroAtorId",
                table: "VinculoAtorPersonagem",
                column: "CadastroAtorId");

            migrationBuilder.CreateIndex(
                name: "IX_VinculoAtorPersonagem_RegistrarFilmeId",
                table: "VinculoAtorPersonagem",
                column: "RegistrarFilmeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VinculoAtorPersonagem");
        }
    }
}
