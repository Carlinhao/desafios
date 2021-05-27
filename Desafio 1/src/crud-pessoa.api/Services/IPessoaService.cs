using crud_pessoa.api.Dtos;
using crud_pessoa.api.Dtos.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crud_pessoa.api.Services
{
    public interface IPessoaService
    {
        Task<IEnumerable<PessoaDto>> GetAllAsync(string cpf = "");
        Task<ResultResponse> InsertAsync(PessoaDto pessoa);
        Task<ResultResponse> UpdateAsync(PessoaUpdateDto pessoa);
        Task<bool> DeleteAsync(int id);
    }
}
