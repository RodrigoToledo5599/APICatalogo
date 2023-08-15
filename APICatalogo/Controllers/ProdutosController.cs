using APICatalogo.Data;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
	[ApiController]
	//[Route("api/produtos/{action}")]
	[Route("api/[controller]/{action}")]
	public class ProdutosController : ControllerBase
	{
		private readonly AppDbContext _db;
		public ProdutosController(AppDbContext db)
		{
			_db = db;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Produto>> getProdutos()
		{
			var produtos = _db.Produtos.ToList();
			if (produtos is null)
				return StatusCode(404,"Não foi possível encontrar nenhum produto");
			else
				return produtos;
		}

		[HttpGet("{id}",Name="getProduto")]

		public ActionResult<Produto> getProduto(int id)
		{
			var produto = _db.Produtos.FirstOrDefault(c => c.ProdutoId == id);
			if (produto is null)
				return StatusCode(404,$"Não foi possível achar o produto de id:{id}");
			else
				return produto;
		}

		/*
		[HttpGet("{id}", Name = "getProdutoECategoria")]
		public ActionResult<Produto> getProdutoECategoria(int id)
		{
			var produto = _db.Produtos.Include(c => c.Categoria).FirstOrDefault(c => c.ProdutoId == id);
			if (produto is null)
				return NotFound("Nao deu pra achar não, sorry");
			else
				return produto;
		}
		*/

		[HttpPost]
		public ActionResult CriarProduto([FromBody]Produto produto)
		{
			
			if (produto != null)
			{
				_db.Produtos.Add(produto);
				_db.SaveChanges();
				return new CreatedAtRouteResult("getProduto", new {id = produto.ProdutoId},produto);
			}

			else
				return BadRequest();

			
		}

		[HttpPut("{id:int}")]
		public ActionResult AtualizarProduto(int id, [FromBody] Produto produto)
		{
			if(id != produto.ProdutoId)
				return BadRequest();

			_db.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			//_db.Produtos.Update(produto); --> mesma coisa q fazer isso
			_db.SaveChanges();

			return Ok(produto);


		}

		[HttpDelete("{id:int}")]
		public ActionResult DeletarItem(int id)
		{
			var produto = _db.Produtos.FirstOrDefault(c => c.ProdutoId == id);
			if (produto is null) return NotFound();
			else
			{
				_db.Remove(produto);
				_db.SaveChanges();
				return Ok(produto);
			}

		}



	}
}
