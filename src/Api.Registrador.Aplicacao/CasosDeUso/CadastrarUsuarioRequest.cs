using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entidades;
using Aplicacao.Interfaces;
using LiteDB;
using MediatR;

namespace Aplicacao.CasosDeUso
{
    
    public class CadastrarUsuarioRequest : IRequest<CadastrarUsuarioResponse>
    {
        public string IdUsuario { get; private set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<Telefone> Telefones {get; set;}
    }

    public class CadastrarUsuarioRequestHandler : IRequestHandler<CadastrarUsuarioRequest, CadastrarUsuarioResponse>
    {

        public IUsuarioRepositorio UsuarioRepositorio {get; set;}

        public CadastrarUsuarioRequestHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            UsuarioRepositorio = usuarioRepositorio;
        }

        public Task<CadastrarUsuarioResponse> Handle(CadastrarUsuarioRequest request, CancellationToken cancellationToken)
        {
            try
            {                
                List<Telefone> telefones = new List<Telefone>(request.Telefones);

                Usuario usuario = new Usuario(request.Nome, request.Email, request.Senha, telefones);
                    usuario.Data_Criacao = DateTime.Now;
                    usuario.Data_Atualizacao = usuario.Data_Criacao;
                    usuario.Ultimo_Login = usuario.Data_Criacao;

                if(UsuarioRepositorio.BuscarEmail(request.Email) == null)
                    {
                        UsuarioRepositorio.Inserir(usuario);

                        return Task.FromResult(new CadastrarUsuarioResponse(){id = usuario.IdUsuario , 
                                                                            data_criacao = usuario.Data_Criacao,
                                                                            data_atualizacao = usuario.Data_Atualizacao,
                                                                            ultimo_login = usuario.Ultimo_Login,
                                                                            token = usuario.Token});
                    }
                    else
                        {
                            throw new Exception("E-mail já cadastrado no Banco de Dados!!!");
                        }
            }
            catch (Exception)
            {
                throw new Exception("E-mail já cadastrado no Banco de Dados!!!");
            }
        }
    }

    public class CadastrarUsuarioResponse
    {
        public string id {get; set;}
        public DateTime data_criacao {get; set;}
        public DateTime data_atualizacao {get; set;}
        public DateTime ultimo_login {get; set;}
        public string token {get; set;}
    }
}
