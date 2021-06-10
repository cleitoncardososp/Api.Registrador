using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Aplicacao.Interfaces;
using Domain.Entidades;
using Dominio.Excecoes;
using LiteDB;
using MediatR;

namespace Aplicacao.CasosDeUso
{
    public class EntrarUsuarioRequest : IRequest<EntrarUsuarioResponse>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }

    public class EntrarUsuarioRequestHandler : IRequestHandler<EntrarUsuarioRequest, EntrarUsuarioResponse>
    {
        public IUsuarioRepositorio UsuarioRepositorio {get; set;}
        public EntrarUsuarioRequestHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            UsuarioRepositorio = usuarioRepositorio;
        }

        public Task<EntrarUsuarioResponse> Handle(EntrarUsuarioRequest request, CancellationToken cancellationToken)
        {
                    Usuario usuario = UsuarioRepositorio.BuscarEmail(request.Email);
                    if(usuario == null)
                    {
                        throw new Exception("Usuário e/ou senha inválidos");
                    }
                
                    if(usuario.Senha == request.Senha)
                    {
                        //Gerar um novo token
                        usuario.Token = Guid.NewGuid().ToString();
                        
                        //Alterar a data do último login
                        usuario.Ultimo_Login = DateTime.Now;
                        usuario.Data_Atualizacao = usuario.Ultimo_Login;

                        //Persistir no banco de dados
                        UsuarioRepositorio.Atualizar(usuario);

                        //retornar o mesmo objeto retornado do Signup
                        return Task.FromResult(new EntrarUsuarioResponse(){id = usuario.IdUsuario , 
                                                                            data_criacao = usuario.Data_Criacao,
                                                                            data_atualizacao = usuario.Data_Atualizacao,
                                                                            ultimo_login = usuario.Ultimo_Login,
                                                                            token = usuario.Token});
                    }else
                    {
                        throw new Exception("Usuário e/ou senha inválidos");
                    }
        }
    }

    public class EntrarUsuarioResponse
    {
        public string id {get; set;}
        public DateTime data_criacao {get; set;}
        public DateTime data_atualizacao {get; set;}
        public DateTime ultimo_login {get; set;}
        public string token {get; set;}
    }
}
