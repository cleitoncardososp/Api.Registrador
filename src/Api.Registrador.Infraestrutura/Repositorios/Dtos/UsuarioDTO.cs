using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entidades;

namespace Infraestrutura.Repositorios.Dtos
{
    public class UsuarioDTO
    {
        [Key]
        [MaxLength(50)]
        public string IdUsuario { get; set; }
        [MaxLength(100)]
        public DateTime Data_Criacao {get; set;}
        [MaxLength(100)]
        public DateTime Data_Atualizacao {get; set;}
        [MaxLength(100)]
        public DateTime Ultimo_Login {get; set;}
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Senha { get; set; }
        [Required]
        [MaxLength(100)]
        public List<Telefone> Telefones {get; set;}
    }
}
