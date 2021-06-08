using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entidades;
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
        public Task<CadastrarUsuarioResponse> Handle(CadastrarUsuarioRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<Telefone> telefones = new List<Telefone>(request.Telefones);

                Usuario usuario = new Usuario(request.Nome, request.Email, request.Senha, telefones);
                    usuario.Data_Criacao = DateTime.Now;
                    usuario.Data_Atualizacao = usuario.Data_Criacao;
                    usuario.Ultimo_Login = usuario.Data_Criacao;

                return Task.FromResult(new CadastrarUsuarioResponse(){Status = 200, Message = "Usuario Cadastrado",  Data = usuario});
            }
            catch (Exception ex)
            {
                return Task.FromResult(new CadastrarUsuarioResponse(){Status=1, Message = "ERRO: " + ex});
            }
        }
    }

    public class CadastrarUsuarioResponse
    {
        public int Status {get; set;}
        
        public string Message {get; set;}

        public Usuario Data {get; set;}
    }

}
