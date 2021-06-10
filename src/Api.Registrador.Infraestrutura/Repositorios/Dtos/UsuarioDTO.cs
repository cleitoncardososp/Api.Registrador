using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entidades;

namespace Infraestrutura.Repositorios.Dtos
{
    public class UsuarioDTO
    {
        public int _id {get; set;}
        public string IdUsuario { get; set; }
        public DateTime Data_Criacao {get; set;}
        public DateTime Data_Atualizacao {get; set;}
        public DateTime Ultimo_Login {get; set;}
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<Telefone> Telefones {get; set;}
        public string Token {get; set;}

        public UsuarioDTO(string idUsuario, DateTime data_Criacao, DateTime data_Atualizacao, DateTime ultimo_Login, string nome, string email, string senha, List<Telefone> telefones, string token)
        {
            IdUsuario = idUsuario;
            Data_Criacao = data_Criacao;
            Data_Atualizacao = data_Atualizacao;
            Ultimo_Login = ultimo_Login;
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefones = telefones;
            Token = token;
        }

        public UsuarioDTO()
        {
            
        }
    }
}
