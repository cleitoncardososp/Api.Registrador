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
    [Route("[controller]/cadastro")]
    
    public class RegistradorController : ControllerBase
    {
        
        public static IWebHostEnvironment _enviroment;
        public IMediator Mediator{get;set;}
        private readonly ILogger<RegistradorController> _logger;

        public RegistradorController(IMediator mediator, ILogger<RegistradorController> logger, IWebHostEnvironment environment)
        {
            Mediator = mediator;
            _logger = logger;
            _enviroment = environment;
        }

        //Cadastrar Usuario
        [HttpPost()]
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
                catch (ExcecaoDominio ex)
                {
                    _logger.LogInformation("Exceção de domínio ao rodar o caso de uso", ex);
                    return BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning("Erro não tratado", ex);
                    return BadRequest(ex.Message);
                }
            }
            else
                {
                    _logger.LogInformation("Modelo Inválido", ModelState);
                    return BadRequest(ModelState);
                    
                }
        }

    }    
}

