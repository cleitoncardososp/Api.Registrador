using System;
using System.Collections.Generic;
using Dominio.Excecoes;

namespace Domain.Entidades
{
    public class Usuario
    {
        public String IdUsuario { get; set; }
        public DateTime Data_Criacao {get; set;}
        public DateTime Data_Atualizacao {get; set;}
        public DateTime Ultimo_Login {get; set;}
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<Telefone> Telefones {get; set;}
        public String Token {get; set;}

        public Usuario(String nome, string email, string senha, List<Telefone> telefones)
        {
            ExcecaoDominio.LancarQuando(() => String.IsNullOrEmpty(nome), "Nome do Usuário é Obrigatório");
            ExcecaoDominio.LancarQuando(() => String.IsNullOrEmpty(email), "E-mail do Usuário é Obrigatório");
            ExcecaoDominio.LancarQuando(() => String.IsNullOrEmpty(senha), "Senha do Usuário é Obrigatório");
            ExcecaoDominio.LancarQuando(() => telefones==null || telefones.Count==0, "Telefones do Usuário é Obrigatório");

            IdUsuario = Guid.NewGuid().ToString();
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefones = telefones;
            Token = Guid.NewGuid().ToString();
        }
    
        internal Usuario(String idUsuario, DateTime data_criacao, DateTime data_atualizacao, DateTime ultimo_login, string nome, string email, string senha, List<Telefone> telefones, String token)
        {
            IdUsuario = idUsuario;
            Data_Criacao = data_criacao;
            Data_Atualizacao = data_atualizacao;
            Ultimo_Login = ultimo_login;
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefones = telefones;
            Token = token;
        }
        
    }
}