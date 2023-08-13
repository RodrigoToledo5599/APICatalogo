using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Categoria> Categorias { get; set; }
		public DbSet<Produto> Produtos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<Produto>().HasData(
				new Produto { ProdutoId = 1, Nome = "Coca-Diet",Descricao="Refrigerante Cola 350 ml",Preco = 5.45M, Estoque= 140, DataCadastro = DateTime.Now, CategoriaId=1},
				new Produto { ProdutoId = 2, Nome = "Sanduiche de atum",Descricao="Sanduiche de atum com maionese",Preco = 8.40M, Estoque= 78, DataCadastro = DateTime.Now, CategoriaId=2},
				new Produto { ProdutoId = 3, Nome = "Pudim ",Descricao="Pudim de leite condensado 150g",Preco = 10.0M, Estoque= 78, DataCadastro = DateTime.Now, CategoriaId=3}
			
				
				
				);


			modelBuilder.Entity<Categoria>().HasData(
				new Categoria { CategoriaId= 1, Nome = "Bebidas" },
				new Categoria { CategoriaId = 2,  Nome = "Lanches" },
				new Categoria { CategoriaId = 3, Nome = "Sobremesas" }




				);


		}

	}
}
