using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entidades;

namespace Infraestrutura.Repositorios.Dtos
{
    public class UsuarioDTO
    {
        public string IdUsuario { get; set; }
        public DateTime Data_Criacao {get; set;}
        public DateTime Data_Atualizacao {get; set;}
        public DateTime Ultimo_Login {get; set;}
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<Telefone> Telefones {get; set;}
    }
}
