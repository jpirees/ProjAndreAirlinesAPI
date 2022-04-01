using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjAndreAirlinesAPI.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aeroporto_Endereco_EnderecoId",
                table: "Aeroporto");

            migrationBuilder.DropForeignKey(
                name: "FK_Passageiro_Endereco_EnderecoId",
                table: "Passageiro");

            migrationBuilder.DropForeignKey(
                name: "FK_Voo_Aeroporto_DestinoId",
                table: "Voo");

            migrationBuilder.DropForeignKey(
                name: "FK_Voo_Aeroporto_OrigemId",
                table: "Voo");

            migrationBuilder.RenameColumn(
                name: "OrigemId",
                table: "Voo",
                newName: "OrigemSigla");

            migrationBuilder.RenameColumn(
                name: "DestinoId",
                table: "Voo",
                newName: "DestinoSigla");

            migrationBuilder.RenameIndex(
                name: "IX_Voo_OrigemId",
                table: "Voo",
                newName: "IX_Voo_OrigemSigla");

            migrationBuilder.RenameIndex(
                name: "IX_Voo_DestinoId",
                table: "Voo",
                newName: "IX_Voo_DestinoSigla");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Passageiro",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Aeroporto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Aeroporto_Endereco_EnderecoId",
                table: "Aeroporto",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Passageiro_Endereco_EnderecoId",
                table: "Passageiro",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voo_Aeroporto_DestinoSigla",
                table: "Voo",
                column: "DestinoSigla",
                principalTable: "Aeroporto",
                principalColumn: "Sigla",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voo_Aeroporto_OrigemSigla",
                table: "Voo",
                column: "OrigemSigla",
                principalTable: "Aeroporto",
                principalColumn: "Sigla",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aeroporto_Endereco_EnderecoId",
                table: "Aeroporto");

            migrationBuilder.DropForeignKey(
                name: "FK_Passageiro_Endereco_EnderecoId",
                table: "Passageiro");

            migrationBuilder.DropForeignKey(
                name: "FK_Voo_Aeroporto_DestinoSigla",
                table: "Voo");

            migrationBuilder.DropForeignKey(
                name: "FK_Voo_Aeroporto_OrigemSigla",
                table: "Voo");

            migrationBuilder.RenameColumn(
                name: "OrigemSigla",
                table: "Voo",
                newName: "OrigemId");

            migrationBuilder.RenameColumn(
                name: "DestinoSigla",
                table: "Voo",
                newName: "DestinoId");

            migrationBuilder.RenameIndex(
                name: "IX_Voo_OrigemSigla",
                table: "Voo",
                newName: "IX_Voo_OrigemId");

            migrationBuilder.RenameIndex(
                name: "IX_Voo_DestinoSigla",
                table: "Voo",
                newName: "IX_Voo_DestinoId");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Passageiro",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Aeroporto",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Aeroporto_Endereco_EnderecoId",
                table: "Aeroporto",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passageiro_Endereco_EnderecoId",
                table: "Passageiro",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voo_Aeroporto_DestinoId",
                table: "Voo",
                column: "DestinoId",
                principalTable: "Aeroporto",
                principalColumn: "Sigla",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voo_Aeroporto_OrigemId",
                table: "Voo",
                column: "OrigemId",
                principalTable: "Aeroporto",
                principalColumn: "Sigla",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
