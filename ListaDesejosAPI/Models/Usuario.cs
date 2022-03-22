using System.ComponentModel.DataAnnotations;

namespace ListaDesejosAPI.Data
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        public string Loguin { get; set; }

        public string Senha { get; set; }
    }
}