using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjAndreAirlinesAPI.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeronave",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeronave", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aeroporto",
                columns: table => new
                {
                    Sigla = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeroporto", x => x.Sigla);
                    table.ForeignKey(
                        name: "FK_Aeroporto_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passageiro",
                columns: table => new
                {
                    Cpf = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNasc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiro", x => x.Cpf);
                    table.ForeignKey(
                        name: "FK_Passageiro_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Voo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrigemSigla = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DestinoSigla = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AeronaveId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HorarioEmbarque = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorarioDesembarque = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voo_Aeronave_AeronaveId",
                        column: x => x.AeronaveId,
                        principalTable: "Aeronave",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voo_Aeroporto_DestinoSigla",
                        column: x => x.DestinoSigla,
                        principalTable: "Aeroporto",
                        principalColumn: "Sigla",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voo_Aeroporto_OrigemSigla",
                        column: x => x.OrigemSigla,
                        principalTable: "Aeroporto",
                        principalColumn: "Sigla",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Passagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VooId = table.Column<int>(type: "int", nullable: true),
                    PassageiroCpf = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClasseId = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passagem_Classe_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Passagem_Passageiro_PassageiroCpf",
                        column: x => x.PassageiroCpf,
                        principalTable: "Passageiro",
                        principalColumn: "Cpf",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Passagem_Voo_VooId",
                        column: x => x.VooId,
                        principalTable: "Voo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aeroporto_EnderecoId",
                table: "Aeroporto",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Passageiro_EnderecoId",
                table: "Passageiro",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_ClasseId",
                table: "Passagem",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_PassageiroCpf",
                table: "Passagem",
                column: "PassageiroCpf");

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_VooId",
                table: "Passagem",
                column: "VooId");

            migrationBuilder.CreateIndex(
                name: "IX_Voo_AeronaveId",
                table: "Voo",
                column: "AeronaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Voo_DestinoSigla",
                table: "Voo",
                column: "DestinoSigla");

            migrationBuilder.CreateIndex(
                name: "IX_Voo_OrigemSigla",
                table: "Voo",
                column: "OrigemSigla");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passagem");

            migrationBuilder.DropTable(
                name: "Classe");

            migrationBuilder.DropTable(
                name: "Passageiro");

            migrationBuilder.DropTable(
                name: "Voo");

            migrationBuilder.DropTable(
                name: "Aeronave");

            migrationBuilder.DropTable(
                name: "Aeroporto");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
