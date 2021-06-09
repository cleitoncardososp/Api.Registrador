using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aplicacao.Interfaces;
using Domain.Entidades;
using LiteDB;
using MediatR;

namespace Aplicacao.CasosDeUso
{
    
    public class BuscarUsuarioRequest : IRequest<BuscarUsuarioResponse>
    {
        public string Token { get; private set; }
    }

    public class BuscarUsuarioRequestHandler : IRequestHandler<BuscarUsuarioRequest, BuscarUsuarioResponse>
    {
        public IUsuarioRepositorio UsuarioRepositorio {get; set;}
        public BuscarUsuarioRequestHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            UsuarioRepositorio = usuarioRepositorio;
        }

        public Task<BuscarUsuarioResponse> Handle(BuscarUsuarioRequest request, CancellationToken cancellationToken)
        {
            try
            {
                UsuarioRepositorio.Buscar(request.Token);

                return Task.FromResult(new BuscarUsuarioResponse(){Status = 200, Message = "Usuario Localizado "});
            }
            catch (Exception ex)
            {
                return Task.FromResult(new BuscarUsuarioResponse(){Status=1, Message = "ERRO: " + ex});
            }
        }
    }

    public class BuscarUsuarioResponse
    {
        public int Status {get; set;}
        
        public string Message {get; set;}

        public Usuario Data {get; set;}
    }

}
