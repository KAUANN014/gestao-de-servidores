
﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoServidores.Migrations
{
    /// <inheritdoc />
    public partial class initialb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lotacoes_Orgaos_OrgaoId",
                table: "Lotacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Servidores_Lotacoes_LotacaoId",
                table: "Servidores");

            migrationBuilder.DropForeignKey(
                name: "FK_Servidores_Orgaos_OrgaoId",
                table: "Servidores");

            migrationBuilder.AddForeignKey(
                name: "FK_Lotacoes_Orgaos_OrgaoId",
                table: "Lotacoes",
                column: "OrgaoId",
                principalTable: "Orgaos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servidores_Lotacoes_LotacaoId",
                table: "Servidores",
                column: "LotacaoId",
                principalTable: "Lotacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servidores_Orgaos_OrgaoId",
                table: "Servidores",
                column: "OrgaoId",
                principalTable: "Orgaos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lotacoes_Orgaos_OrgaoId",
                table: "Lotacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Servidores_Lotacoes_LotacaoId",
                table: "Servidores");

            migrationBuilder.DropForeignKey(
                name: "FK_Servidores_Orgaos_OrgaoId",
                table: "Servidores");

            migrationBuilder.AddForeignKey(
                name: "FK_Lotacoes_Orgaos_OrgaoId",
                table: "Lotacoes",
                column: "OrgaoId",
                principalTable: "Orgaos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servidores_Lotacoes_LotacaoId",
                table: "Servidores",
                column: "LotacaoId",
                principalTable: "Lotacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Servidores_Orgaos_OrgaoId",
                table: "Servidores",
                column: "OrgaoId",
                principalTable: "Orgaos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
