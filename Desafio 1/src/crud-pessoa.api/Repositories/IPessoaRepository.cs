using crud_pessoa.api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crud_pessoa.api.Repositories
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> GetAllAsync(string cpf = "");
        Task<int> InsertAsync(Pessoa pessoa);
        Task<int> UpdateAsync(Pessoa pessoa);
        Task<int> DeleteAsync(int id);
    }
}
