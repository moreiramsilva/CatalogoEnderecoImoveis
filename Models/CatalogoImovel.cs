using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationTeste.Models
{
    [Table("CatalogoImovel")]
    public class CatalogoImovel
    {
        [Display(Name= "Id")]
        [Column("Id")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Cep")]
        [Column("Cep")]
        [Required]
        public string Cep { get; set; }

        [Display(Name = "Rua")]
        [Column("Rua")]
        [MaxLength(250)]
        [Required]
        public string Rua { get; set; }

        [Display(Name = "Numero")]
        [Column("Numero")]
        [Required]
        public int Numero { get; set; }

        [Display(Name = "Complemento")]
        [Column("Complemento")]
        [MaxLength(250)]
        public string? Complemento { get; set; }

        [Display(Name = "Proprietario")]
        [Column("ProprietarioId")]
        [Required]
        public Proprietario? Proprietario { get; set; }

    }
}
