using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MilenioRadartonaAPI.Migrations
{
    public partial class Postgres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RelatoriosReqs",
                columns: table => new
                {
                    RelatorioReqId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Lat = table.Column<double>(nullable: false),
                    Lon = table.Column<double>(nullable: false),
                    Evento = table.Column<string>(nullable: true),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Fim = table.Column<DateTime>(nullable: false),
                    Raio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatoriosReqs", x => x.RelatorioReqId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ReqInfosId = table.Column<int>(nullable: false),
                    TipoUsuario = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Bloqueado = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    CriacaoDeConta = table.Column<DateTime>(nullable: false),
                    UltimaMudancaDeSenha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Chaves",
                columns: table => new
                {
                    ChaveId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Token = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Authenticated = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Expiration = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chaves", x => x.ChaveId);
                    table.ForeignKey(
                        name: "FK_Chaves_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onUpdate: ReferentialAction.Cascade,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requisicoes",
                columns: table => new
                {
                    RequisicaoInfosId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UsuarioId = table.Column<int>(nullable: false),
                    DiasAutenticadosId = table.Column<int>(nullable: false),
                    QtdReqFeitasNoDia = table.Column<int>(nullable: false),
                    QtdReqDiaMax = table.Column<int>(nullable: false),
                    AcessoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisicoes", x => x.RequisicaoInfosId);
                    table.ForeignKey(
                        name: "FK_Requisicoes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onUpdate: ReferentialAction.Cascade,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acessos",
                columns: table => new
                {
                    AcessoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Url = table.Column<string>(nullable: false),
                    RelatorioReqId = table.Column<int>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    RequisicaoInfosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acessos", x => x.AcessoId);
                    table.ForeignKey(
                        name: "FK_Acessos_RelatoriosReqs_RelatorioReqId",
                        column: x => x.RelatorioReqId,
                        principalTable: "RelatoriosReqs",
                        principalColumn: "RelatorioReqId",
                        onUpdate: ReferentialAction.Cascade,
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acessos_Requisicoes_RequisicaoInfosId",
                        column: x => x.RequisicaoInfosId,
                        principalTable: "Requisicoes",
                        principalColumn: "RequisicaoInfosId",
                        onUpdate: ReferentialAction.Cascade,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiasLogados",
                columns: table => new
                {
                    DiasAutenticadosId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DiaAutenticado = table.Column<DateTime>(nullable: false),
                    RequisicaoInfosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasLogados", x => x.DiasAutenticadosId);
                    table.ForeignKey(
                        name: "FK_DiasLogados_Requisicoes_RequisicaoInfosId",
                        column: x => x.RequisicaoInfosId,
                        principalTable: "Requisicoes",
                        principalColumn: "RequisicaoInfosId",
                        onUpdate: ReferentialAction.Cascade,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acessos_RelatorioReqId",
                table: "Acessos",
                column: "RelatorioReqId");

            migrationBuilder.CreateIndex(
                name: "IX_Acessos_RequisicaoInfosId",
                table: "Acessos",
                column: "RequisicaoInfosId");

            migrationBuilder.CreateIndex(
                name: "IX_Chaves_UsuarioId",
                table: "Chaves",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiasLogados_RequisicaoInfosId",
                table: "DiasLogados",
                column: "RequisicaoInfosId");

            migrationBuilder.CreateIndex(
                name: "IX_Requisicoes_UsuarioId",
                table: "Requisicoes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acessos");

            migrationBuilder.DropTable(
                name: "Chaves");

            migrationBuilder.DropTable(
                name: "DiasLogados");

            migrationBuilder.DropTable(
                name: "RelatoriosReqs");

            migrationBuilder.DropTable(
                name: "Requisicoes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
