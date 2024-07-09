using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControladeDeBar.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class BancoDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBConta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    EmAberto = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBConta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBGarcom",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGarcom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBProduto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBProduto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBMesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "varchar(10)", nullable: false),
                    Conta_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBMesa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBMesa_TBConta",
                        column: x => x.Conta_Id,
                        principalTable: "TBConta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Garcom_Id = table.Column<int>(type: "int", nullable: false),
                    Produto_Id = table.Column<int>(type: "int", nullable: false),
                    Mesa_Id = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPedido_TBGarcom",
                        column: x => x.Garcom_Id,
                        principalTable: "TBGarcom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBPedido_TBMesa",
                        column: x => x.Mesa_Id,
                        principalTable: "TBMesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBPedido_TBProduto",
                        column: x => x.Produto_Id,
                        principalTable: "TBProduto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBConta_TBPedido",
                columns: table => new
                {
                    ContaId = table.Column<int>(type: "int", nullable: false),
                    PedidosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBConta_TBPedido", x => new { x.ContaId, x.PedidosId });
                    table.ForeignKey(
                        name: "FK_TBConta_TBPedido_TBConta_ContaId",
                        column: x => x.ContaId,
                        principalTable: "TBConta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBConta_TBPedido_TBPedido_PedidosId",
                        column: x => x.PedidosId,
                        principalTable: "TBPedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBConta_TBPedido_PedidosId",
                table: "TBConta_TBPedido",
                column: "PedidosId");

            migrationBuilder.CreateIndex(
                name: "IX_TBMesa_Conta_Id",
                table: "TBMesa",
                column: "Conta_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBPedido_Garcom_Id",
                table: "TBPedido",
                column: "Garcom_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBPedido_Mesa_Id",
                table: "TBPedido",
                column: "Mesa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBPedido_Produto_Id",
                table: "TBPedido",
                column: "Produto_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBConta_TBPedido");

            migrationBuilder.DropTable(
                name: "TBPedido");

            migrationBuilder.DropTable(
                name: "TBGarcom");

            migrationBuilder.DropTable(
                name: "TBMesa");

            migrationBuilder.DropTable(
                name: "TBProduto");

            migrationBuilder.DropTable(
                name: "TBConta");
        }
    }
}
