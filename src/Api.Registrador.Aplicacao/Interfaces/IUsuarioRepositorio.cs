using System;
using Domain.Entidades;

namespace Aplicacao.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario Consultar(string idUsuario);
        void Inserir(Usuario usuario);
        void Atualizar(Usuario usuario);
    }
}
