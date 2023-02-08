using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NgolaTur.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaRestaurante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCategoria = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaRestaurante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassificacaoHotel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeClassificacaoHotel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificacaoHotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProvincia = table.Column<string>(nullable: true),
                    EstadoProvincia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPontoTuristico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoPontoTuristico = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPontoTuristico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCidade = table.Column<string>(nullable: true),
                    EstadoCidade = table.Column<string>(nullable: true),
                    IdProvincia = table.Column<int>(nullable: false),
                    Populacao = table.Column<int>(nullable: false),
                    ProvinciaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidade_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeHotel = table.Column<string>(nullable: true),
                    EstadoHotel = table.Column<string>(nullable: true),
                    IdCidade = table.Column<int>(nullable: false),
                    IdClassificacaoHotel = table.Column<int>(nullable: false),
                    NumeroDeQuartos = table.Column<int>(nullable: false),
                    CidadeId = table.Column<int>(nullable: true),
                    ClassificacaoHotelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotel_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hotel_ClassificacaoHotel_ClassificacaoHotelId",
                        column: x => x.ClassificacaoHotelId,
                        principalTable: "ClassificacaoHotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PontoTuristico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePontoTuristico = table.Column<string>(nullable: true),
                    IdCidade = table.Column<int>(nullable: false),
                    IdTipoPontoTuristico = table.Column<int>(nullable: false),
                    CidadeId = table.Column<int>(nullable: true),
                    TipoPontoTuristicoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontoTuristico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontoTuristico_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PontoTuristico_TipoPontoTuristico_TipoPontoTuristicoId",
                        column: x => x.TipoPontoTuristicoId,
                        principalTable: "TipoPontoTuristico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeRestaurante = table.Column<string>(nullable: true),
                    IdCidade = table.Column<int>(nullable: false),
                    IdCategoriaRestaurante = table.Column<int>(nullable: false),
                    CidadeId = table.Column<int>(nullable: true),
                    CategoriaRestauranteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurante_CategoriaRestaurante_CategoriaRestauranteId",
                        column: x => x.CategoriaRestauranteId,
                        principalTable: "CategoriaRestaurante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Restaurante_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoQuarto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipoQuarto = table.Column<string>(nullable: true),
                    Preco = table.Column<decimal>(nullable: false),
                    IdHotel = table.Column<int>(nullable: false),
                    HotelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoQuarto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoQuarto_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservaPontoTuristico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    DataSaida = table.Column<DateTime>(nullable: false),
                    IdPontoTuristico = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<string>(nullable: true),
                    PontoTuristicoId = table.Column<int>(nullable: true),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaPontoTuristico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaPontoTuristico_PontoTuristico_PontoTuristicoId",
                        column: x => x.PontoTuristicoId,
                        principalTable: "PontoTuristico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservaPontoTuristico_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservaQuartoHotel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    DataSaida = table.Column<DateTime>(nullable: false),
                    IdTipoQuartoHotel = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<string>(nullable: true),
                    PontoTuristicoId = table.Column<int>(nullable: true),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaQuartoHotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaQuartoHotel_PontoTuristico_PontoTuristicoId",
                        column: x => x.PontoTuristicoId,
                        principalTable: "PontoTuristico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservaQuartoHotel_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservaRestaurante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    DataSaida = table.Column<DateTime>(nullable: false),
                    IdRestaurante = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<string>(nullable: true),
                    PontoTuristicoId = table.Column<int>(nullable: true),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaRestaurante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaRestaurante_Restaurante_PontoTuristicoId",
                        column: x => x.PontoTuristicoId,
                        principalTable: "Restaurante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservaRestaurante_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_ProvinciaId",
                table: "Cidade",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_CidadeId",
                table: "Hotel",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_ClassificacaoHotelId",
                table: "Hotel",
                column: "ClassificacaoHotelId");

            migrationBuilder.CreateIndex(
                name: "IX_PontoTuristico_CidadeId",
                table: "PontoTuristico",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_PontoTuristico_TipoPontoTuristicoId",
                table: "PontoTuristico",
                column: "TipoPontoTuristicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaPontoTuristico_PontoTuristicoId",
                table: "ReservaPontoTuristico",
                column: "PontoTuristicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaPontoTuristico_UsuarioId",
                table: "ReservaPontoTuristico",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaQuartoHotel_PontoTuristicoId",
                table: "ReservaQuartoHotel",
                column: "PontoTuristicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaQuartoHotel_UsuarioId",
                table: "ReservaQuartoHotel",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaRestaurante_PontoTuristicoId",
                table: "ReservaRestaurante",
                column: "PontoTuristicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaRestaurante_UsuarioId",
                table: "ReservaRestaurante",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurante_CategoriaRestauranteId",
                table: "Restaurante",
                column: "CategoriaRestauranteId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurante_CidadeId",
                table: "Restaurante",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoQuarto_HotelId",
                table: "TipoQuarto",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservaPontoTuristico");

            migrationBuilder.DropTable(
                name: "ReservaQuartoHotel");

            migrationBuilder.DropTable(
                name: "ReservaRestaurante");

            migrationBuilder.DropTable(
                name: "TipoQuarto");

            migrationBuilder.DropTable(
                name: "PontoTuristico");

            migrationBuilder.DropTable(
                name: "Restaurante");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "TipoPontoTuristico");

            migrationBuilder.DropTable(
                name: "CategoriaRestaurante");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "ClassificacaoHotel");

            migrationBuilder.DropTable(
                name: "Provincia");
        }
    }
}
