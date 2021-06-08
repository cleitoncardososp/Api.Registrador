using System;
using Aplicacao.Interfaces;
using Domain.Entidades;
using Dominio.Fabricas;
using Infraestrutura.Repositorios.Dtos;

namespace Infraestrutura.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {


        //public ApplicationContext Context{get; set;}
        public IUsuarioFabrica UsuarioFabrica {get; set;}



        public void Atualizar(Usuario usuario)
        {
            
        }

        public Usuario Consultar(string idUsuario)
        {
            return null;
        }

        public void Inserir(Usuario usuario)
        {
            UsuarioDTO usuarioDto = new UsuarioDTO();
                usuarioDto.IdUsuario = usuario.IdUsuario;
                usuarioDto.Data_Criacao = usuario.Data_Criacao;
                usuarioDto.Data_Atualizacao = usuario.Data_Atualizacao;
                usuarioDto.Ultimo_Login = usuario.Ultimo_Login;
                usuarioDto.Nome = usuario.Nome;
                usuarioDto.Email = usuario.Email;
                usuarioDto.Senha = usuario.Senha;
                usuarioDto.Telefones = usuario.Telefones;

            //Context.Usuario.Add(usuarioDto);

            //Context.SaveChanges();
        }
    }
}
