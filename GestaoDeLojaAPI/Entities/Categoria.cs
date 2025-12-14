using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoDeLojaAPI.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="O nome é obrigatório")]
        public string? Nome { get; set; }
        public int? Ordem { get; set; }
        public string? UrlImagem { get; set; }
        public byte[]? Imagem { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

    }
}
