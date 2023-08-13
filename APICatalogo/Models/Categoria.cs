using System.ComponentModel.DataAnnotations;

namespace APICatalogo.Models
{
	public class Categoria
	{
		[Key]
		public int CategoriaId { get; set; }
        public string? Nome { get; set; }
        public string? ImagemUrl { get; set; }
		public ICollection<Produto>? Produtos { get; set; }
	}
}
