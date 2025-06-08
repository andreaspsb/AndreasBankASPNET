using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndreasBank.Migrations
{
    /// <inheritdoc />
    public partial class HerancaConta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Agencia_AgenciaNumero",
                table: "Contas");

            migrationBuilder.DropTable(
                name: "Agencia");

            migrationBuilder.DropColumn(
                name: "CnpjTitular",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "CpfTitular",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "EmailTitular",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "EnderecoTitular",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "TelefoneTitular",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Titular",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Clientes",
                newName: "CPF");

            migrationBuilder.AddColumn<string>(
                name: "CnpjEmpregador",
                table: "Contas",
                type: "TEXT",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LimiteChequeEspecial",
                table: "Contas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxaRendimento",
                table: "Contas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitularCPF",
                table: "Contas",
                type: "TEXT",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Agencias",
                columns: table => new
                {
                    Numero = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencias", x => x.Numero);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contas_TitularCPF",
                table: "Contas",
                column: "TitularCPF");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Agencias_AgenciaNumero",
                table: "Contas",
                column: "AgenciaNumero",
                principalTable: "Agencias",
                principalColumn: "Numero",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Clientes_TitularCPF",
                table: "Contas",
                column: "TitularCPF",
                principalTable: "Clientes",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Agencias_AgenciaNumero",
                table: "Contas");

            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Clientes_TitularCPF",
                table: "Contas");

            migrationBuilder.DropTable(
                name: "Agencias");

            migrationBuilder.DropIndex(
                name: "IX_Contas_TitularCPF",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "CnpjEmpregador",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "LimiteChequeEspecial",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "TaxaRendimento",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "TitularCPF",
                table: "Contas");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Clientes",
                newName: "Cpf");

            migrationBuilder.AddColumn<string>(
                name: "CnpjTitular",
                table: "Contas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CpfTitular",
                table: "Contas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailTitular",
                table: "Contas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnderecoTitular",
                table: "Contas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "Contas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Contas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TelefoneTitular",
                table: "Contas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Titular",
                table: "Contas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Clientes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Clientes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Clientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Clientes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Agencia",
                columns: table => new
                {
                    Numero = table.Column<string>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Endereco = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencia", x => x.Numero);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Agencia_AgenciaNumero",
                table: "Contas",
                column: "AgenciaNumero",
                principalTable: "Agencia",
                principalColumn: "Numero",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
