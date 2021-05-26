using crud_pessoa.api.Dtos;
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

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }


        [HttpGet]
        [Route("listar-pessoa")]
        public async Task<ActionResult<IEnumerable<PessoaDto>>> GetPessoasAsync([FromQuery] Documento documento)
        {
            var result = await _pessoaService.GetAllAsync(documento.Cpf);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Route("cadastrar-pessoa")]
        public async Task<ActionResult<int?>> InsertPessoaAsync([FromBody] PessoaDto pessoaDto)
        {
            var result = await _pessoaService.InsertAsync(pessoaDto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        [Route("atualizar-pessoa")]
        public async Task<ActionResult<int?>> InsertPessoaAsync([FromBody] PessoaUpdateDto pessoaUpdateDto)
        {
            var result = await _pessoaService.UpdateAsync(pessoaUpdateDto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        [Route("deletar-pessoa/{id:int}")]
        public async Task<ActionResult<int?>> DeletarPessoaAsync(int id)
        {
            var result = await _pessoaService.DeleteAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }

    public class Documento
    {
        public string Cpf { get; set; }
    }
}
