using System;
using Domain.Entidades;

namespace Aplicacao.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario Buscar(string idUsuario);
        void Inserir(Usuario usuario);
        void Atualizar(Usuario usuario);
    }
}
