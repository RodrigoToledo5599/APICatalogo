using APICatalogo.Data;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;

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
				return NotFound("Nao deu pra achar nao ");
			else
				return produtos;
		}

		[HttpGet("{id}")]

		public ActionResult<Produto> getProduto(int id)
		{
			var produto = _db.Produtos.FirstOrDefault(c => c.ProdutoId == id);
			if (produto is null)
				return NotFound("Nao deu pra achar não, sorry;");
			else
				return produto;
		}


		[HttpPost]

		public ActionResult CriarProduto(Produto produto)
		{
			if (ModelState.IsValid)
			{
				_db.Produtos.Add(produto);
				_db.SaveChanges();
				return new CreatedAtRouteResult("getProduto",
					new {id = produto.ProdutoId},produto);

			}

			else if (produto is null)
				return BadRequest();

			else 
				return BadRequest();
		}


	}
}
