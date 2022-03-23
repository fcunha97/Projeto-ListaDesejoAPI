using ListaDesejosAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace ListaDesejosAPI.Models
{
    public class Desejo
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Apenas letras")]
        public string Descricao { get; set; }
        public Usuario Usuario { get; set; }

        public int UsuarioId { get; set; }
    }
}
