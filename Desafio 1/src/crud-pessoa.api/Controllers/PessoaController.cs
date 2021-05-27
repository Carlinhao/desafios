using crud_pessoa.api.Configs.Notifications;
using crud_pessoa.api.Dtos;
using crud_pessoa.api.Dtos.Responses;
using crud_pessoa.api.Services;
using Microsoft.AspNetCore.Mvc;
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

        public PessoaController(IPessoaService pessoaService,
                                INotificacaoContext notificacaoContext)
        {
            _pessoaService = pessoaService;
            _notificacaoContext = notificacaoContext;
        }


        [HttpGet]
        [Route("listar-pessoa")]
        public async Task<ActionResult<IEnumerable<PessoaDto>>> GetPessoasAsync([FromQuery] Documento documento)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _pessoaService.GetAllAsync(documento.Cpf);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost]
        [Route("cadastrar-pessoa")]
        public async Task<ActionResult<ResultResponse>> InsertPessoaAsync([FromBody] PessoaDto pessoaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _pessoaService.InsertAsync(pessoaDto);

            if (_notificacaoContext.HasNotification())
            {
                return BadRequest(_notificacaoContext.RetornarNoticacoes());
            }

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        [Route("atualizar-pessoa")]
        public async Task<ActionResult<ResultResponse>> InsertPessoaAsync([FromBody] PessoaUpdateDto pessoaUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _pessoaService.UpdateAsync(pessoaUpdateDto);

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPut]
        [Route("deletar-pessoa/{id:int}")]
        public async Task<ActionResult<bool>> DeletarPessoaAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _pessoaService.DeleteAsync(id);
            return Ok(result);
        }
    }

    public class Documento
    {
        public string Cpf { get; set; }
    }
}
