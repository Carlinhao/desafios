using AutoMapper;
using crud_pessoa.api.Configs.Notifications;
using crud_pessoa.api.Configs.Validators;
using crud_pessoa.api.Dtos;
using crud_pessoa.api.Dtos.Responses;
using crud_pessoa.api.Entities;
using crud_pessoa.api.Repositories;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud_pessoa.api.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ILogger<PessoaService> _logger;
        private readonly INotificacaoContext _notificacaoContext;
        private readonly IMapper _mapper;
        public PessoaService(IPessoaRepository pessoaRepository,
                             IMapper mapper,
                             ILogger<PessoaService> logger,
                             INotificacaoContext notificacaoContext)
        {
            _pessoaRepository = pessoaRepository;            
            _mapper = mapper;
            _logger = logger;
            _notificacaoContext = notificacaoContext;
        }        

        public async Task<IEnumerable<PessoaDto>> GetAllAsync(string cpf = "")
        {
            _logger.LogInformation("Buscar todos", cpf);
            var result = _mapper.Map<IEnumerable<PessoaDto>>(await _pessoaRepository.GetAllAsync(cpf));

            return result;
        }

        public async Task<ResultResponse> InsertAsync(PessoaDto pessoaDto)
        {
            var error = ValidadorResult(new PessoaValidator(), pessoaDto);

            if(error.Errors.Count() > 0)
            {
                foreach (var item in error.Errors.Select(x => x.ErrorMessage).ToArray().Distinct())
                {
                    _notificacaoContext.AddNotification("PessoaService", item, "InsertAsync");
                }
                return new ResultResponse();
            }

            _logger.LogInformation("Inserir um novo registro: ", pessoaDto);
            var pessoaEntity = _mapper.Map<Pessoa>(pessoaDto);

            return await _pessoaRepository.InsertAsync(pessoaEntity);
        }

        public async Task<ResultResponse> UpdateAsync(PessoaUpdateDto pessoaUpdateDto)
        {
           

            _logger.LogInformation("Atualizando um registro: ", pessoaUpdateDto);
            var pessoaEntity = _mapper.Map<Pessoa>(pessoaUpdateDto);

            return await _pessoaRepository.InsertAsync(pessoaEntity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            _logger.LogInformation("Deletando registro de id: ", id);
            var result = await _pessoaRepository.DeleteAsync(id);

            return result;
        }

        public ValidationResult ValidadorResult<TV, TE>(TV validacao, TE entidade)
            where TV : AbstractValidator<TE> where TE : class
        {
            return validacao.Validate(entidade);
        }
    }
}
