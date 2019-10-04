using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Serrana.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_AGROTOXICO",
                columns: table => new
                {
                    Agro_Id = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Qtd_Disponivel = table.Column<int>(nullable: false),
                    Unidade_Medida = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_AGROTOXICO", x => x.Agro_Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_CULTURA",
                columns: table => new
                {
                    Cultura_Id = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 20, nullable: false),
                    Mes_Inicio = table.Column<int>(nullable: false),
                    Mes_Fim = table.Column<int>(nullable: false),
                    Data_Inicio = table.Column<string>(nullable: true),
                    TempoMaximo = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CULTURA", x => x.Cultura_Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_FUNCIONARIO",
                columns: table => new
                {
                    Matricula = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Cargo = table.Column<string>(maxLength: 20, nullable: false),
                    Data_Admissao = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FUNCIONARIO", x => x.Matricula);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRAGA",
                columns: table => new
                {
                    Praga_Id = table.Column<int>(nullable: false),
                    Nome_Popular = table.Column<string>(maxLength: 50, nullable: false),
                    Nome_Cientifico = table.Column<string>(maxLength: 50, nullable: false),
                    Estacao = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRAGA", x => x.Praga_Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_AREA",
                columns: table => new
                {
                    Area_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tamanho = table.Column<float>(maxLength: 20, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Cultura_Id = table.Column<int>(nullable: false),
                    Maticula_Funcionario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_AREA", x => x.Area_Id);
                    table.ForeignKey(
                        name: "FK_TB_AREA_TB_CULTURA_Cultura_Id",
                        column: x => x.Cultura_Id,
                        principalTable: "TB_CULTURA",
                        principalColumn: "Cultura_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_AREA_TB_FUNCIONARIO_Maticula_Funcionario",
                        column: x => x.Maticula_Funcionario,
                        principalTable: "TB_FUNCIONARIO",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ATAQUE",
                columns: table => new
                {
                    Cultura_Id = table.Column<int>(nullable: false),
                    Praga_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ATAQUE", x => new { x.Cultura_Id, x.Praga_Id });
                    table.ForeignKey(
                        name: "FK_TB_ATAQUE_TB_CULTURA_Cultura_Id",
                        column: x => x.Cultura_Id,
                        principalTable: "TB_CULTURA",
                        principalColumn: "Cultura_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ATAQUE_TB_PRAGA_Praga_Id",
                        column: x => x.Praga_Id,
                        principalTable: "TB_PRAGA",
                        principalColumn: "Praga_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_COMBATE",
                columns: table => new
                {
                    Praga_Id = table.Column<int>(nullable: false),
                    Agro_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_COMBATE", x => new { x.Agro_Id, x.Praga_Id });
                    table.ForeignKey(
                        name: "FK_TB_COMBATE_TB_AGROTOXICO_Agro_Id",
                        column: x => x.Agro_Id,
                        principalTable: "TB_AGROTOXICO",
                        principalColumn: "Agro_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_COMBATE_TB_PRAGA_Praga_Id",
                        column: x => x.Praga_Id,
                        principalTable: "TB_PRAGA",
                        principalColumn: "Praga_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_AplicacaoAgrotoxico",
                columns: table => new
                {
                    Qtd_Aplicada = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    Area_Id = table.Column<int>(nullable: false),
                    Agro_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_AplicacaoAgrotoxico", x => new { x.Area_Id, x.Agro_Id });
                    table.ForeignKey(
                        name: "FK_TB_AplicacaoAgrotoxico_TB_AGROTOXICO_Agro_Id",
                        column: x => x.Agro_Id,
                        principalTable: "TB_AGROTOXICO",
                        principalColumn: "Agro_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_AplicacaoAgrotoxico_TB_AREA_Area_Id",
                        column: x => x.Area_Id,
                        principalTable: "TB_AREA",
                        principalColumn: "Area_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_AplicacaoAgrotoxico_Agro_Id",
                table: "TB_AplicacaoAgrotoxico",
                column: "Agro_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_AREA_Cultura_Id",
                table: "TB_AREA",
                column: "Cultura_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_AREA_Maticula_Funcionario",
                table: "TB_AREA",
                column: "Maticula_Funcionario");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ATAQUE_Praga_Id",
                table: "TB_ATAQUE",
                column: "Praga_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TB_COMBATE_Praga_Id",
                table: "TB_COMBATE",
                column: "Praga_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_AplicacaoAgrotoxico");

            migrationBuilder.DropTable(
                name: "TB_ATAQUE");

            migrationBuilder.DropTable(
                name: "TB_COMBATE");

            migrationBuilder.DropTable(
                name: "TB_AREA");

            migrationBuilder.DropTable(
                name: "TB_AGROTOXICO");

            migrationBuilder.DropTable(
                name: "TB_PRAGA");

            migrationBuilder.DropTable(
                name: "TB_CULTURA");

            migrationBuilder.DropTable(
                name: "TB_FUNCIONARIO");
        }
    }
}
