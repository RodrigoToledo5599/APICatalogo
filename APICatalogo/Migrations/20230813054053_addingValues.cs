using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class addingValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "ImagemUrl", "Nome" },
                values: new object[,]
                {
                    { 1, null, "Bebidas" },
                    { 2, null, "Lanches" },
                    { 3, null, "Sobremesas" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "ProdutoId", "CategoriaId", "DataCadastro", "Descricao", "Estoque", "ImagemUrl", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 8, 13, 2, 40, 53, 1, DateTimeKind.Local).AddTicks(6583), "Refrigerante Cola 350 ml", 140f, null, "Coca-Diet", 5.45m },
                    { 2, 2, new DateTime(2023, 8, 13, 2, 40, 53, 1, DateTimeKind.Local).AddTicks(6594), "Sanduiche de atum com maionese", 78f, null, "Sanduiche de atum", 8.40m },
                    { 3, 3, new DateTime(2023, 8, 13, 2, 40, 53, 1, DateTimeKind.Local).AddTicks(6596), "Pudim de leite condensado 150g", 78f, null, "Pudim ", 10.0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "CategoriaId",
                keyValue: 3);
        }
    }
}
