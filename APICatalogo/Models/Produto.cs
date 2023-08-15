using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models
{
	[Table("Produtos")]
	public class Produto
	{
		
		[Key]
		[JsonIgnore]
		public int ProdutoId { get; set; }
		
		[Required]
		[StringLength(127)]
		public string? Nome { get; set; }
		
		[Required]
		public string? Descricao { get; set; }
		
		[Column(TypeName = "decimal(10,2)")]
		public decimal Preco { get; set; }
		
		[StringLength(511)]
		public string? ImagemUrl { get; set; }
		
		public float Estoque { get; set; }
		
		public DateTime DataCadastro { get; set; }
		
		public int CategoriaId { get; set; }
		[JsonIgnore]
		public Categoria? Categoria { get; set; }
	}
}
