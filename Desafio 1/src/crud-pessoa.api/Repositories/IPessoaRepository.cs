using crud_pessoa.api.Dtos.Responses;
using crud_pessoa.api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crud_pessoa.api.Repositories
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> GetAllAsync(string cpf = "");
        Task<ResultResponse> InsertAsync(Pessoa pessoa);
        Task<ResultResponse> UpdateAsync(Pessoa pessoa);
        Task<bool> DeleteAsync(int id);
    }
}
