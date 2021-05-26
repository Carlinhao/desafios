using AutoMapper;
using crud_pessoa.api.Dtos;
using crud_pessoa.api.Entities;
using crud_pessoa.api.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crud_pessoa.api.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;
        public PessoaService(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }        

        public async Task<IEnumerable<PessoaDto>> GetAllAsync(string cpf = "")
        {
            var result = _mapper.Map<IEnumerable<PessoaDto>>(await _pessoaRepository.GetAllAsync(cpf));

            return result;
        }

        public async Task<int> InsertAsync(PessoaDto pessoaDto)
        {
            var pessoaEntity = _mapper.Map<Pessoa>(pessoaDto);

            return await _pessoaRepository.InsertAsync(pessoaEntity);
        }

        public async Task<int> UpdateAsync(PessoaUpdateDto pessoaUpdateDto)
        {
            var pessoaEntity = _mapper.Map<Pessoa>(pessoaUpdateDto);

            return await _pessoaRepository.InsertAsync(pessoaEntity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = await _pessoaRepository.DeleteAsync(id);

            return result;
        }
    }
}
