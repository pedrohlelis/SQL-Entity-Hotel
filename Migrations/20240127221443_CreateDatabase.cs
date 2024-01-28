using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    CodCargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCargo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.CodCargo);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CodCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EnderecoCliente = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Nacionalidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CodCliente);
                });

            migrationBuilder.CreateTable(
                name: "Consumiveis",
                columns: table => new
                {
                    CodConsumivel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoConsumivel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorConsumivel = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumiveis", x => x.CodConsumivel);
                });

            migrationBuilder.CreateTable(
                name: "Filiais",
                columns: table => new
                {
                    CodFilial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFilial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EnderecoFilial = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    NumeroDeQuartos = table.Column<short>(type: "smallint", nullable: false),
                    Estrelas = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiais", x => x.CodFilial);
                });

            migrationBuilder.CreateTable(
                name: "FormasPagamento",
                columns: table => new
                {
                    CodFormaPag = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormaDePagamento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasPagamento", x => x.CodFormaPag);
                });

            migrationBuilder.CreateTable(
                name: "ServicosLavanderia",
                columns: table => new
                {
                    CodServLav = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoServLav = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorServLav = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicosLavanderia", x => x.CodServLav);
                });

            migrationBuilder.CreateTable(
                name: "TiposQuarto",
                columns: table => new
                {
                    CodTipoQuarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDoQuarto = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposQuarto", x => x.CodTipoQuarto);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    CodFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFuncionario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FkCargoCodCargo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.CodFuncionario);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Cargos_FkCargoCodCargo",
                        column: x => x.FkCargoCodCargo,
                        principalTable: "Cargos",
                        principalColumn: "CodCargo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Quartos",
                columns: table => new
                {
                    CodQuarto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adaptavel = table.Column<bool>(type: "bit", nullable: false),
                    NumeroQuarto = table.Column<short>(type: "smallint", nullable: false),
                    CapacidadeMax = table.Column<byte>(type: "tinyint", nullable: false),
                    FkTiposQuartoCodTipoQuarto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quartos", x => x.CodQuarto);
                    table.ForeignKey(
                        name: "FK_Quartos_TiposQuarto_FkTiposQuartoCodTipoQuarto",
                        column: x => x.FkTiposQuartoCodTipoQuarto,
                        principalTable: "TiposQuarto",
                        principalColumn: "CodTipoQuarto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    CodReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cancelada = table.Column<bool>(type: "bit", nullable: false),
                    ColchaoAdicional = table.Column<bool>(type: "bit", nullable: false),
                    FkClientesCodCliente = table.Column<int>(type: "int", nullable: false),
                    FkQuartosCodQuarto = table.Column<int>(type: "int", nullable: false),
                    FkFuncionariosCodFuncionario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.CodReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_FkClientesCodCliente",
                        column: x => x.FkClientesCodCliente,
                        principalTable: "Clientes",
                        principalColumn: "CodCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Funcionarios_FkFuncionariosCodFuncionario",
                        column: x => x.FkFuncionariosCodFuncionario,
                        principalTable: "Funcionarios",
                        principalColumn: "CodFuncionario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Quartos_FkQuartosCodQuarto",
                        column: x => x.FkQuartosCodQuarto,
                        principalTable: "Quartos",
                        principalColumn: "CodQuarto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    CodConta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkReservaCodReserva = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.CodConta);
                    table.ForeignKey(
                        name: "FK_Conta_Reservas_FkReservaCodReserva",
                        column: x => x.FkReservaCodReserva,
                        principalTable: "Reservas",
                        principalColumn: "CodReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumo",
                columns: table => new
                {
                    CodConsumo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FkConsumiveisCodConsumivel = table.Column<int>(type: "int", nullable: false),
                    ConsumidoCodConsumivel = table.Column<int>(type: "int", nullable: true),
                    FkContaCodConta = table.Column<int>(type: "int", nullable: false),
                    EntregueNoQuarto = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraConsumido = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumo", x => x.CodConsumo);
                    table.ForeignKey(
                        name: "FK_Consumo_Consumiveis_ConsumidoCodConsumivel",
                        column: x => x.ConsumidoCodConsumivel,
                        principalTable: "Consumiveis",
                        principalColumn: "CodConsumivel");
                    table.ForeignKey(
                        name: "FK_Consumo_Conta_FkContaCodConta",
                        column: x => x.FkContaCodConta,
                        principalTable: "Conta",
                        principalColumn: "CodConta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotasFiscais",
                columns: table => new
                {
                    CodNotaFiscal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FkContaCodConta = table.Column<int>(type: "int", nullable: false),
                    FkFormasPagamentoCodFormaPag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasFiscais", x => x.CodNotaFiscal);
                    table.ForeignKey(
                        name: "FK_NotasFiscais_Conta_FkContaCodConta",
                        column: x => x.FkContaCodConta,
                        principalTable: "Conta",
                        principalColumn: "CodConta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotasFiscais_FormasPagamento_FkFormasPagamentoCodFormaPag",
                        column: x => x.FkFormasPagamentoCodFormaPag,
                        principalTable: "FormasPagamento",
                        principalColumn: "CodFormaPag",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServLavPrestados",
                columns: table => new
                {
                    CodServLavPrestado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKServicosLavanderiaCodServLav = table.Column<int>(type: "int", nullable: false),
                    ServicoCodServLav = table.Column<int>(type: "int", nullable: true),
                    FKContaCodConta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServLavPrestados", x => x.CodServLavPrestado);
                    table.ForeignKey(
                        name: "FK_ServLavPrestados_Conta_FKContaCodConta",
                        column: x => x.FKContaCodConta,
                        principalTable: "Conta",
                        principalColumn: "CodConta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServLavPrestados_ServicosLavanderia_ServicoCodServLav",
                        column: x => x.ServicoCodServLav,
                        principalTable: "ServicosLavanderia",
                        principalColumn: "CodServLav");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consumo_ConsumidoCodConsumivel",
                table: "Consumo",
                column: "ConsumidoCodConsumivel");

            migrationBuilder.CreateIndex(
                name: "IX_Consumo_FkContaCodConta",
                table: "Consumo",
                column: "FkContaCodConta");

            migrationBuilder.CreateIndex(
                name: "IX_Conta_FkReservaCodReserva",
                table: "Conta",
                column: "FkReservaCodReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_FkCargoCodCargo",
                table: "Funcionarios",
                column: "FkCargoCodCargo");

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_FkContaCodConta",
                table: "NotasFiscais",
                column: "FkContaCodConta");

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscais_FkFormasPagamentoCodFormaPag",
                table: "NotasFiscais",
                column: "FkFormasPagamentoCodFormaPag");

            migrationBuilder.CreateIndex(
                name: "IX_Quartos_FkTiposQuartoCodTipoQuarto",
                table: "Quartos",
                column: "FkTiposQuartoCodTipoQuarto");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_FkClientesCodCliente",
                table: "Reservas",
                column: "FkClientesCodCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_FkFuncionariosCodFuncionario",
                table: "Reservas",
                column: "FkFuncionariosCodFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_FkQuartosCodQuarto",
                table: "Reservas",
                column: "FkQuartosCodQuarto");

            migrationBuilder.CreateIndex(
                name: "IX_ServLavPrestados_FKContaCodConta",
                table: "ServLavPrestados",
                column: "FKContaCodConta");

            migrationBuilder.CreateIndex(
                name: "IX_ServLavPrestados_ServicoCodServLav",
                table: "ServLavPrestados",
                column: "ServicoCodServLav");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consumo");

            migrationBuilder.DropTable(
                name: "Filiais");

            migrationBuilder.DropTable(
                name: "NotasFiscais");

            migrationBuilder.DropTable(
                name: "ServLavPrestados");

            migrationBuilder.DropTable(
                name: "Consumiveis");

            migrationBuilder.DropTable(
                name: "FormasPagamento");

            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "ServicosLavanderia");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Quartos");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "TiposQuarto");
        }
    }
}
