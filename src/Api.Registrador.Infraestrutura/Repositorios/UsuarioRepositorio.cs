using System.Data.Common;
using System;
using Aplicacao.Interfaces;
using Domain.Entidades;
using Dominio.Fabricas;
using Infraestrutura.Repositorios.Dtos;
using LiteDB;

namespace Infraestrutura.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {       
    
        public IUsuarioFabrica UsuarioFabrica {get; set;}



        public void Atualizar(Usuario usuario)
        {
            
        }

        public Usuario Buscar(string token)
        {
            using (var db = new LiteDatabase("banco.db"))
            {
                var usuario = db.GetCollection<Usuario>().FindOne(x => x.Token == token);                            
                

                
                return usuario;
            }
        }

        public void Inserir(Usuario usuario)
        {
            using (var db = new LiteDatabase("banco.db"))
            {
                var usuarioCollection = db.GetCollection<Usuario>("usuarios");
                usuarioCollection.Insert(usuario);
                db.Commit();
            }
        }
    }
}
