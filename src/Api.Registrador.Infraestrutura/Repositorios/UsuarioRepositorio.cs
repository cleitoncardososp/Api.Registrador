using System.Linq;
using System.Data.Common;
using System;
using Aplicacao.Interfaces;
using Domain.Entidades;
using Dominio.Fabricas;
using Infraestrutura.Repositorios.Dtos;
using LiteDB;
using Microsoft.Extensions.Logging;
using Aplicacao.CasosDeUso;

namespace Infraestrutura.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {       
        public IUsuarioFabrica UsuarioFabrica {get; set;}
        private readonly ILogger<UsuarioRepositorio> _logger;
        public UsuarioRepositorio(IUsuarioFabrica usuarioFabrica, ILogger<UsuarioRepositorio> logger)
        {
            UsuarioFabrica = usuarioFabrica;
            _logger = logger;
        }


        //Recebe um Usuario, converte este usuario para usuarioDto, depois adiciona no Banco.
        public void Inserir(Usuario usuario)
        {
            using (var db = new LiteDatabase("banco.db"))
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
                    usuarioDto.Token = usuario.Token;

                var usuarioCollection = db.GetCollection<UsuarioDTO>("usuarios");
                usuarioCollection.Insert(usuarioDto);
                db.Commit();
            }
        }

        //Recebe um idUsuario, pesquisa no Banco, converte de Dto para Usuário do domínio e retorna o objeto
        public Usuario Buscar(String idUsuario)
        {
            using (var db = new LiteDatabase("banco.db"))
            {
                var usuarios = db.GetCollection<UsuarioDTO>("usuarios");
                var result = usuarios.FindOne(x => x.IdUsuario == idUsuario);

                UsuarioDTO usuarioDto = new UsuarioDTO(result.IdUsuario,
                                                        result.Data_Criacao,
                                                        result.Data_Atualizacao,
                                                        result.Ultimo_Login,
                                                        result.Nome,
                                                        result.Email,
                                                        result.Senha,
                                                        result.Telefones,
                                                        result.Token);
                Usuario usuario = UsuarioFabrica.CriarInstancia(usuarioDto.IdUsuario,
                                                                usuarioDto.Data_Criacao,
                                                                usuarioDto.Data_Atualizacao,
                                                                usuarioDto.Ultimo_Login,
                                                                usuarioDto.Nome,
                                                                usuarioDto.Email,
                                                                usuarioDto.Senha,
                                                                usuarioDto.Telefones,
                                                                usuarioDto.Token
                                                                );
                return usuario;
            }
        }


        //Busca no repositorio o email para o SignIn
        public Usuario BuscarEmail(String email)
        {
            using (var db = new LiteDatabase("banco.db"))
            {   
                var usuarios = db.GetCollection<UsuarioDTO>("usuarios");
                var result = usuarios.FindOne(x => x.Email == email);

                    if(result != null)
                    {
                        UsuarioDTO usuarioDto = new UsuarioDTO(result.IdUsuario,
                                                            result.Data_Criacao,
                                                            result.Data_Atualizacao,
                                                            result.Ultimo_Login,
                                                            result.Nome,
                                                            result.Email,
                                                            result.Senha,
                                                            result.Telefones,
                                                            result.Token);
                        Usuario usuario = UsuarioFabrica.CriarInstancia(usuarioDto.IdUsuario,
                                                                    usuarioDto.Data_Criacao,
                                                                    usuarioDto.Data_Atualizacao,
                                                                    usuarioDto.Ultimo_Login,
                                                                    usuarioDto.Nome,
                                                                    usuarioDto.Email,
                                                                    usuarioDto.Senha,
                                                                    usuarioDto.Telefones,
                                                                    usuarioDto.Token
                                                                    );
                        return usuario;
                    }else
                        {
                            return null;
                        }
            }
        }

        public void Atualizar(Usuario usuario)
        {
            using (var db = new LiteDatabase("banco.db"))
            {   
                var usuarios = db.GetCollection<UsuarioDTO>("usuarios");
                var user = usuarios.FindOne(x => x.IdUsuario == usuario.IdUsuario);   
                    
                    user.Token = usuario.Token;
                    user.Data_Atualizacao = usuario.Data_Atualizacao;
                    user.Ultimo_Login = usuario.Ultimo_Login;

                    usuarios.Update(user);

                    db.Commit();
            }
        }
    }
}
