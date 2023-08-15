using APICatalogo.Data;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
	[ApiController]
	[Route("api/[controller]/{action}")]
	public class CategoriaController : ControllerBase
	{
		private readonly AppDbContext _db;
		public CategoriaController(AppDbContext db)
		{
			_db = db;
		}
		
		[HttpGet("getCategorias")]
		public ActionResult<IEnumerable<Categoria>> getCategorias()
		{
			var Categorias = _db.Categorias.AsNoTracking().ToList();
			if (Categorias is null)
				return NotFound("Nao deu pra achar nao ");
			else
				return Categorias;
		}

		[HttpGet("getCategoriasEProdutos")]
		public ActionResult<IEnumerable<Categoria>> getCategoriasEProdutos()
		{
			var Categorias = _db.Categorias.AsNoTracking().Include(p => p.Produtos).ToList();
			if (Categorias is null)
				return NotFound("Nao deu pra achar nao ");
			else
				return Categorias;
		}

		[HttpGet("{id}", Name = "getCategoria")]

		public ActionResult<Categoria> getCategoria(int id)
		{
			var Categoria = _db.Categorias.AsNoTracking().FirstOrDefault(c => c.CategoriaId == id);
			if (Categoria is null)
				return NotFound("Nao deu pra achar não, sorry");
			else
				return Categoria;
		}


		[HttpPost]
		public ActionResult CriarCategoria([FromBody] Categoria categoria)
		{

			if (categoria != null)
			{
				_db.Categorias.Add(categoria);
				_db.SaveChanges();
				return new CreatedAtRouteResult("getCategoria", new { id = categoria.CategoriaId }, categoria);
			}

			else
				return BadRequest();


		}

		[HttpPut("{id:int}")]
		public ActionResult AtualizarCategoria(int id, [FromBody] Categoria categoria)
		{
			if (id != categoria.CategoriaId)
				return BadRequest();

			_db.Entry(categoria).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			//_db.Categorias.Update(Categoria); --> mesma coisa q fazer isso
			_db.SaveChanges();

			return Ok(categoria);


		}

		[HttpDelete("{id:int}")]
		public ActionResult DeletarItem(int id)
		{
			var categoria = _db.Categorias.FirstOrDefault(c => c.CategoriaId == id);
			if (categoria is null) return NotFound();
			else
			{
				_db.Remove(categoria);
				_db.SaveChanges();
				return Ok(categoria);
			}

		}
	}
}
