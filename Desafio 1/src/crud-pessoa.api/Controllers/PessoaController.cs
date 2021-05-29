using crud_pessoa.api.Configs.Notifications;
using crud_pessoa.api.Dtos;
using crud_pessoa.api.Dtos.Responses;
using crud_pessoa.api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crud_pessoa.api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;
        private readonly INotificacaoContext _notificacaoContext;
        private readonly ILogger<PessoaController> _logger;

        public PessoaController(IPessoaService pessoaService,
                                INotificacaoContext notificacaoContext,
                                ILogger<PessoaController> logger)
        {
            _pessoaService = pessoaService;
            _notificacaoContext = notificacaoContext;
            _logger = logger;
        }


        [HttpGet]
        [Route("listar-pessoa")]
        public async Task<ActionResult<IEnumerable<InsertPessoaDto>>> GetPessoasAsync([FromQuery] Documento documento)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _logger.LogInformation("Listar pessoa: ", documento);

            var result = await _pessoaService.GetAllAsync(documento.Cpf);
            _logger.LogInformation("Resultado da pesquisa : ", result);

            if (_notificacaoContext.HasNotification())
            {
                return BadRequest(_notificacaoContext.RetornarNoticacoes());
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("cadastrar-pessoa")]
        public async Task<ActionResult<ResultResponse>> InsertPessoaAsync([FromBody] InsertPessoaDto pessoaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _logger.LogInformation("InsertPessoaAsync pessoa: ", pessoaDto);

            var result = await _pessoaService.InsertAsync(pessoaDto);
            _logger.LogInformation("Resultado da InsertPessoaAsync : ", result);

            if (_notificacaoContext.HasNotification())
            {
                return BadRequest(_notificacaoContext.RetornarNoticacoes());
            }

            return Ok(result);
        }

        [HttpPut]
        [Route("atualizar-pessoa")]
        public async Task<ActionResult<ResultResponse>> UpdatePessoaAsync([FromBody] PessoaDto pessoaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _pessoaService.UpdateAsync(pessoaDto);

            if (_notificacaoContext.HasNotification())
            {
                return BadRequest(_notificacaoContext.RetornarNoticacoes());
            }

            return Ok(result);
        }

        [HttpPut]
        [Route("deletar-pessoa/{id:int}")]
        public async Task<ActionResult<bool>> DeletarPessoaAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool result = await _pessoaService.DeleteAsync(id);

            if (_notificacaoContext.HasNotification())
            {
                return BadRequest(_notificacaoContext.RetornarNoticacoes());
            }

            return Ok(result);
        }
    }
}
