using System.ComponentModel.DataAnnotations;

namespace Carlos.Models
{
    public class Cliente
    {
        [Key]
        public int Id_cliente { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Data_nasc { get; set; }
        public string Endereco { get; set; }
        public string Celular { get; set; }
    }
}
