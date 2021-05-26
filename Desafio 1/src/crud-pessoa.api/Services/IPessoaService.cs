using crud_pessoa.api.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crud_pessoa.api.Services
{
    public interface IPessoaService
    {
        Task<IEnumerable<PessoaDto>> GetAllAsync(string cpf = "");
        Task<int> InsertAsync(PessoaDto pessoa);
        Task<int> UpdateAsync(PessoaUpdateDto pessoa);
        Task<int> DeleteAsync(int id);
    }
}
