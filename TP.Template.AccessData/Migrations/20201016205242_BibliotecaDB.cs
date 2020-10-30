using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TP2.Template.AccessData.Migrations
{
    public partial class BibliotecaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: false),
                    Dni = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoAlquiler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoAlquiler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    ISBN = table.Column<string>(nullable: false),
                    Titulo = table.Column<string>(nullable: false),
                    Autor = table.Column<string>(nullable: false),
                    Editorial = table.Column<string>(nullable: false),
                    Stock = table.Column<int>(nullable: true),
                    Imagen = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.ISBN);
                });

            migrationBuilder.CreateTable(
                name: "Alquiler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaAlquiler = table.Column<DateTime>(nullable: true),
                    FechaReserva = table.Column<DateTime>(nullable: true),
                    FechaDevolucion = table.Column<DateTime>(nullable: true),
                    ClienteId = table.Column<int>(nullable: false),
                    EstadoAlquilerId = table.Column<int>(nullable: false),
                    ISBN = table.Column<string>(nullable: true),
                    LibroISBN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquiler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alquiler_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquiler_EstadoAlquiler_EstadoAlquilerId",
                        column: x => x.EstadoAlquilerId,
                        principalTable: "EstadoAlquiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alquiler_Libro_LibroISBN",
                        column: x => x.LibroISBN,
                        principalTable: "Libro",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "Apellido", "Dni", "Email", "Nombre" },
                values: new object[] { 1, "Olivera", "34124131", "l.olivera@gmail.com", "Lucas" });

            migrationBuilder.InsertData(
                table: "EstadoAlquiler",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Alquilado" },
                    { 2, "Reservado" },
                    { 3, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "Libro",
                columns: new[] { "ISBN", "Autor", "Editorial", "Imagen", "Stock", "Titulo" },
                values: new object[,]
                {
                    { "1", "Antoine de Saint-Exupéry", "Reynal & Hitchcock", "https://imagessl4.casadellibro.com/a/l/t7/94/9788478887194.jpg", 1, "El Principito" },
                    { "2", "J. K. Rowling", "Salamandra", "https://images-na.ssl-images-amazon.com/images/I/91HHems0BVL.jpg", 3, "Harry Potter y la camara secreta" },
                    { "3", "Dan Brown", "Doubleday", "https://www.planetadelibros.com.ar/usuaris/libros/fotos/167/m_libros/portada_el-codigo-da-vinci_dan-brown_201505260959.jpg", 3, "El código Da Vinci" },
                    { "4", "J.R.R.Tolkien", "George Allen & Unwin", "https://images.cdn1.buscalibre.com/fit-in/360x360/66/1a/661a3760157941a94cb8db3f5a9d5060.jpg", 4, "El Señor de los Anillos" },
                    { "5", "Margaret Mitchell", "Macmillan Publishers", "https://m.media-amazon.com/images/I/517buCKnBjL.jpg", 2, "Lo que el viento se llevó" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_ClienteId",
                table: "Alquiler",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_EstadoAlquilerId",
                table: "Alquiler",
                column: "EstadoAlquilerId");

            migrationBuilder.CreateIndex(
                name: "IX_Alquiler_LibroISBN",
                table: "Alquiler",
                column: "LibroISBN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alquiler");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "EstadoAlquiler");

            migrationBuilder.DropTable(
                name: "Libro");
        }
    }
}
