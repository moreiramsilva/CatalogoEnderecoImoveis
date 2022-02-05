using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationTeste.Models
{
    [Table("Proprietario")]
    public class Proprietario
    {
        [Display(Name = "Id")]
        [Column("Id")]
        [Required]
        public int Id { get; set; }
        
        [Display(Name = "Nome")]
        [Column("Nome")]
        [Required]
        [MaxLength(250)]
        public string Nome { get; set; }

        [Display(Name = "Telefone")]
        [Column("Telefone")]
        [Phone]
        public string? Telefone { get; set; }


    }
}
