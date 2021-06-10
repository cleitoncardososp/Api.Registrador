using System;
using System.Threading.Tasks;
using Aplicacao.CasosDeUso;
using Dominio.Excecoes;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Servico.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        public static IWebHostEnvironment _enviroment;
        public IMediator Mediator{get;set;}
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IMediator mediator, ILogger<UsuarioController> logger, IWebHostEnvironment environment)
        {
            Mediator = mediator;
            _logger = logger;
            _enviroment = environment;
        }

        //SIGN UP - cadadstrar
        [HttpPost("signup")]
        public async Task<ActionResult> Post([FromBody]CadastrarUsuarioRequest request)
        {
            _logger.LogInformation("Recebido Post de Cadastro de Usuario", request);
            if(ModelState.IsValid)
            {
                _logger.LogInformation("Modelo válido, chamando caso de uso");
                try
                {
                    CadastrarUsuarioResponse response = await Mediator.Send(request);
                    _logger.LogInformation("Caso de uso finalizado com sucesso. Retorno do caso de uso", response);
                    return Ok(response);
                }
                catch(Exception ex)
                {
                    return Unauthorized("Mensagem: " + ex.Message);
                }
            }
            else
                {
                    _logger.LogInformation("Modelo Inválido", ModelState);
                    return BadRequest(ModelState);
                }
        }
        

        //SIGN IN - Logar
        [HttpPost("signin")]
        public async Task<ActionResult> EntrarUsuario([FromBody]EntrarUsuarioRequest request)
        {
            try
            {
                _logger.LogInformation("Dentro do Caso de Uso Entrar Usuario");

                EntrarUsuarioResponse response = await Mediator.Send(request);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return Unauthorized("Mensagem: " + ex.Message);
            }
        }


        //BuscarUsuario
        [HttpGet("{IdUsuario}/buscarusuario")]
        public async Task<ActionResult> BuscarUsuario([FromRoute]BuscarUsuarioRequest request)
        {
            try
            {
                _logger.LogInformation("Dentro do Caso de Uso Buscar Usuario");
                
                BuscarUsuarioResponse response = await Mediator.Send(request);
                return Ok(response);
                
            }
            catch (System.Exception ex)
            {
                _logger.LogInformation("Erro não tratado Buscar usuário: " + ex);
                return BadRequest();
            }
        }
    }    
}

