using System;
using System.Collections.Generic;
using Domain.Entidades;

namespace Dominio.Fabricas
{
    public interface IUsuarioFabrica
    {
        Usuario CriarInstancia(string nome, string email, string senha, List<Telefone> telefones);
    }

    public class UsuarioFabrica : IUsuarioFabrica
    {
        public Usuario CriarInstancia(string nome, string email, string senha, List<Telefone> telefones)
        {
            return new Usuario(nome, email, senha, telefones);
        }
    }
}
