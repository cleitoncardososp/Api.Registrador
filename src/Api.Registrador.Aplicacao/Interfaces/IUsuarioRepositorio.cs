using System;
using Domain.Entidades;

namespace Aplicacao.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Usuario Buscar(String idUsuario);
        void Inserir(Usuario usuario);
        void Atualizar(Usuario usuario);
        Usuario BuscarEmail(string email);
    }
}
