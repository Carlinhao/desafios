﻿using crud_pessoa.api.DbContextConfig;
using crud_pessoa.api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crud_pessoa.api.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<PessoaRepository> _logger;
        private readonly DbSet<Pessoa> _dataSet;

        public PessoaRepository(ApplicationDbContext dbContext,
                                ILogger<PessoaRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            _dataSet = _dbContext.Set<Pessoa>();
        }

        public async Task<IEnumerable<Pessoa>> GetAllAsync(string cpf = "")
        {
            _logger.LogInformation("Buscar pessoas", cpf);

            IEnumerable<Pessoa> result;
            try
            {
                if (string.IsNullOrEmpty(cpf))
                    result = (IEnumerable<Pessoa>)await _dataSet.SingleOrDefaultAsync(x => x.Cpf.Equals(cpf));

                result = await _dataSet.ToListAsync();

                _logger.LogInformation("Retorno da consulta", result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: ", ex.Message);
                throw;
            }

            return result;
        }

        public async Task<int> InsertAsync(Pessoa pessoa)
        {
            try
            {
                await _dataSet.AddAsync(pessoa);
                await _dbContext.SaveChangesAsync();

                return 1;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: ", ex.Message);
                throw;
            }
            return 0;
        }

        public async Task<int> UpdateAsync(Pessoa pessoa)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(x => x.Id.Equals(pessoa.Id));
                if (result == null)
                    return 0;

                _dbContext.Entry(result).CurrentValues.SetValues(pessoa);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: ", ex.Message);
                throw;
            }

            return 1;
        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                var result = await _dataSet.SingleOrDefaultAsync(x => x.Id.Equals(id));
                if (result == null)
                    return 0;

                _dataSet.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro: ", ex.Message);
                throw;
            }
            return 1;
        }
    }
}
