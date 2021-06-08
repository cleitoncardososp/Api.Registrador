using System;
using System.Collections.Generic;
using Dominio.Excecoes;

namespace Domain.Entidades
{
    public class Usuario
    {
        public String IdUsuario { get; private set; }
        public DateTime Data_Criacao {get; set;}
        public DateTime Data_Atualizacao {get; set;}
        public DateTime Ultimo_Login {get; set;}
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<Telefone> Telefones {get; set;}
        public String Token {get; set;}

        

        public Usuario(string nome, string email, string senha, List<Telefone> telefones)
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
    }
}