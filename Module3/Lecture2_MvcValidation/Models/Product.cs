using System.ComponentModel.DataAnnotations;

namespace Lecture2.Models
{
    public class Product
    {
        [Required(ErrorMessage="Id inválido")]
        [Range(10, 20, ErrorMessage="O Valor deve estar entre 10 e 20")]
        public int? Id { get; set; }

        [Required(ErrorMessage="O Nome deve ser preenchido")]
        [MinLength(3, ErrorMessage="O Nome deve ter pelo menos 3 digitos")]
        [MaxLength(5, ErrorMessage="O Nome deve ter no máximo 5 digitos")]
        public string Name { get; set; }

        [Required(ErrorMessage="Preço inválido")]
        [Range(1, int.MaxValue, ErrorMessage="O valor não pode ser menor do que 1")]
        public int? Price { get; set; }
    }
}