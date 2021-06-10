using System;
using System.Collections.Generic;
using Domain.Entidades;

namespace Dominio.Fabricas
{
    public interface IUsuarioFabrica
    {
        Usuario CriarInstancia(String idUsuario, DateTime data_criacao, DateTime data_atualizacao, DateTime ultimo_login, string nome, string email, string senha, List<Telefone> telefones, String token);
    }

    public class UsuarioFabrica : IUsuarioFabrica
    {
        public Usuario CriarInstancia(String idUsuario, DateTime data_criacao, DateTime data_atualizacao, DateTime ultimo_login, string nome, string email, string senha, List<Telefone> telefones, String token)
        {
            return new Usuario(idUsuario, data_criacao, data_atualizacao, ultimo_login, nome, email, senha, telefones, token);
        }
    }
}
