using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrestamosGHI.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuiId = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(maxLength: 50, nullable: false),
                    Cedula = table.Column<string>(maxLength: 15, nullable: true),
                    Direccion = table.Column<string>(maxLength: 15, nullable: true),
                    Telefono = table.Column<string>(maxLength: 15, nullable: true),
                    MontoPrestamo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IngresoNeto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Plazo = table.Column<int>(nullable: false),
                    Fprestamo = table.Column<DateTime>(nullable: false),
                    Estatus = table.Column<int>(nullable: false),
                    AprobadaRechasada = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    IdPrestamo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<string>(nullable: true),
                    guidSolicitud = table.Column<string>(nullable: true),
                    ClienteId = table.Column<int>(nullable: false),
                    Usuario = table.Column<int>(nullable: false),
                    Fprestamo = table.Column<DateTime>(nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Interes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FormaPago = table.Column<string>(maxLength: 255, nullable: true),
                    Fpago = table.Column<DateTime>(nullable: false),
                    Plazo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.IdPrestamo);
                    table.ForeignKey(
                        name: "FK_Prestamos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalculoLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuiId = table.Column<string>(nullable: true),
                    PrestamoGuiId = table.Column<string>(nullable: true),
                    NroCuota = table.Column<int>(nullable: false),
                    Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Interes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cuotaMensual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pendiente = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    MontoPagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteId = table.Column<int>(nullable: true),
                    PrestamoIdPrestamo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculoLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalculoLists_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CalculoLists_Prestamos_PrestamoIdPrestamo",
                        column: x => x.PrestamoIdPrestamo,
                        principalTable: "Prestamos",
                        principalColumn: "IdPrestamo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    IdPago = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrestamoId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Cuota = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.IdPago);
                    table.ForeignKey(
                        name: "FK_Pagos_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "IdPrestamo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gastos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PagoId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Concepto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gastos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gastos_Pagos_PagoId",
                        column: x => x.PagoId,
                        principalTable: "Pagos",
                        principalColumn: "IdPago",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalculoLists_ClienteId",
                table: "CalculoLists",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CalculoLists_PrestamoIdPrestamo",
                table: "CalculoLists",
                column: "PrestamoIdPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_PagoId",
                table: "Gastos",
                column: "PagoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_PrestamoId",
                table: "Pagos",
                column: "PrestamoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_ClienteId",
                table: "Prestamos",
                column: "ClienteId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculoLists");

            migrationBuilder.DropTable(
                name: "Gastos");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
