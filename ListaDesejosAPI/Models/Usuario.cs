using ListaDesejosAPI.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ListaDesejosAPI.Data
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Apenas letras")]
        public string Loguin { get; set; }

        [Required]
        public string Senha { get; set; }

        public virtual ICollection<Desejo> Desejos{ get; set; }

    } 
  
}