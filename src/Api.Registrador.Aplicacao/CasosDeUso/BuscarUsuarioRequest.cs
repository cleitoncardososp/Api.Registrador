using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aplicacao.Interfaces;
using Domain.Entidades;
using LiteDB;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacao.CasosDeUso
{
    public class BuscarUsuarioRequest : IRequest<BuscarUsuarioResponse>
    {
        public string IdUsuario { get; set; }
    }

    public class BuscarUsuarioRequestHandler : IRequestHandler<BuscarUsuarioRequest, BuscarUsuarioResponse>
    {
        public IUsuarioRepositorio UsuarioRepositorio {get; set;}
        public ILogger<BuscarUsuarioResponse> Logger{get;set;}
        public BuscarUsuarioRequestHandler(IUsuarioRepositorio usuarioRepositorio, ILogger<BuscarUsuarioResponse> logger)
        {
            UsuarioRepositorio = usuarioRepositorio;
            Logger = logger;
        }

        public Task<BuscarUsuarioResponse> Handle(BuscarUsuarioRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Usuario usuario = UsuarioRepositorio.Buscar(request.IdUsuario); 

                return Task.FromResult(new BuscarUsuarioResponse(){id = usuario.IdUsuario , 
                                                                    data_criacao = usuario.Data_Criacao,
                                                                    data_atualizacao = usuario.Data_Atualizacao,
                                                                    ultimo_login = usuario.Ultimo_Login,
                                                                    nome = usuario.Nome,
                                                                    email = usuario.Email,
                                                                    senha = usuario.Senha,
                                                                    telefones = usuario.Telefones,
                                                                    token = usuario.Token});
            }
            catch (Exception ex)
            {
                return Task.FromResult(new BuscarUsuarioResponse(){nome = "Erro: " + ex});
            }
        }
    }

    public class BuscarUsuarioResponse
    {
        public string id {get; set;}
        public DateTime data_criacao {get; set;}
        public DateTime data_atualizacao {get; set;}
        public DateTime ultimo_login {get; set;}
        public string nome {get; set;}
        public string email {get; set;}
        public string senha {get; set;}
        public List<Telefone> telefones {get; set;}
        public string token {get; set;}
    }
}
