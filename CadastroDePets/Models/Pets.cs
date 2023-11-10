using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroDePets.Models
{
    [Table("Pets")]
    public class Pets
    {
        [Column("Id")]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Column("NomePet")]
        [Display(Name = "NomePet")]
        public string NomePet { get; set; }

        [Column("NomeDono")]
        [Display(Name = "NomeDono")]
        public string NomeDono { get; set; }

        [Column("Telefone")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

    }
}
