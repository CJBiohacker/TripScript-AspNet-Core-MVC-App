using System.ComponentModel.DataAnnotations;

namespace Carlos.Models
{
    public class Viagem
    {
        [Key]
        public int Id_viagem { get; set; }
        [Required]
        public string Destino { get; set; }  //Destino
        public string Data { get; set; }
        public string Horario { get; set; }
        public int Quantidade { get; set; }
        public float Preco { get; set; }

        public int ClienteId_cliente { get; set; }
        public Cliente Cliente { get; set; }
    }
}
