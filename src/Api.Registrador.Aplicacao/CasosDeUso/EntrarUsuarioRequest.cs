using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entidades;
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
        public Task<EntrarUsuarioResponse> Handle(EntrarUsuarioRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new EntrarUsuarioResponse(){});
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
