using crud_pessoa.api.Configs.Notifications;
using crud_pessoa.api.DbContextConfig;
using crud_pessoa.api.Dtos.Responses;
using crud_pessoa.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using crud_pessoa.api.Dtos;

namespace crud_pessoa.api.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<PessoaRepository> _logger;
        private readonly INotificacaoContext _notificacaoContext;
        private readonly IMapper _mapper;
        private readonly DbSet<Pessoa> _dataSet;

        public PessoaRepository(ApplicationDbContext dbContext,
                                ILogger<PessoaRepository> logger,
                                INotificacaoContext notificacaoContext,
                                IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _dataSet = _dbContext.Set<Pessoa>();
            _notificacaoContext = notificacaoContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Pessoa>> GetAllAsync(string cpf = "")
        {
            _logger.LogInformation("Buscar pessoas", cpf);

            IEnumerable<Pessoa> result;
            try
            {
                if (!string.IsNullOrEmpty(cpf))
                {
                    result = await _dataSet.Include(x => x.Contato)
                                           .Include(x => x.Endereco)
                                           .Where(x => x.Cpf == cpf)
                                           .ToListAsync();
                }
                else
                {
                    result = await _dataSet.Include(x => x.Contato)
                                           .Include(x => x.Endereco)
                                           .ToListAsync();
                }

                _logger.LogInformation("Retorno da consulta", result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: ", ex.Message);
                _notificacaoContext.AddNotification("Erro ao buscar dados no banco", ex.Message, "GetAllAsync");

                throw new Exception();
            }
            return result;
        }

        public async Task<ResultResponse> InsertAsync(Pessoa pessoa)
        {
            try
            {
                await _dataSet.AddAsync(pessoa);
                await _dbContext.SaveChangesAsync();

                var result = _mapper.Map<PessoaDto>(pessoa);

                return new ResultResponse { Data = result, Message = "Success", Success = true };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: ", ex.Message);
                _notificacaoContext.AddNotification("Erro ao inserir dados no banco", ex.Message, "InsertAsync");

                throw new Exception();
            }
        }

        public async Task<ResultResponse> UpdateAsync(Pessoa pessoa)
        {
            try
            {
                var retornoPessoa = await _dataSet.Include(x => x.Contato)
                    .Include(x => x.Endereco)
                    .Where(x => x.Id == pessoa.Id).FirstOrDefaultAsync();

                if (retornoPessoa == null)
                    return new ResultResponse { Data = retornoPessoa, Message = "Registro não encontrado", Success = false };

                _dbContext.Entry(retornoPessoa).CurrentValues.SetValues(pessoa);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: ", ex.Message);
                _notificacaoContext.AddNotification("Erro ao atualizar dados no banco", ex.Message, "UpdateAsync");
                throw new Exception();
            }

            var result = _mapper.Map<PessoaDto>(pessoa);
            return new ResultResponse { Data = result, Message = "Success", Success = true };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(x => x.Id.Equals(id));
                if (result == null)
                    return false;

                _dataSet.Remove(result);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: ", ex.Message);
                _notificacaoContext.AddNotification("Erro ao deletar dados no banco", ex.Message, "DeleteAsync");
                
                throw new Exception();
            }
        }

        public async Task<bool> CpfExistAsync(int id)
        {
            try
            {
                var result = await _dataSet.Include(x => x.Contato)
                                           .Include(x => x.Endereco)
                                           .Where(x => x.Id == id).ToListAsync();

                if (result.Count() == 0)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: ", ex.Message);
                _notificacaoContext.AddNotification("Erro ao deletar dados no banco", ex.Message, "DeleteAsync");

                throw new Exception();
            }
        }
    }
}
