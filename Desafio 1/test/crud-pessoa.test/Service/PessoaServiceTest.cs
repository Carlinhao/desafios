using AutoMapper;
using crud_pessoa.api.AutoMapper;
using crud_pessoa.api.Configs.Notifications;
using crud_pessoa.api.Dtos;
using crud_pessoa.api.Dtos.Responses;
using crud_pessoa.api.Entities;
using crud_pessoa.api.Repositories;
using crud_pessoa.api.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Xunit;

namespace crud_pessoa.test.Service
{
    public class PessoaServiceTest
    {
        private readonly Mock<IPessoaRepository> _pessoaRepository;
        private readonly Mock<ILogger<PessoaService>> _logger;
        private readonly Mock<INotificacaoContext> _notificacaoContext;
        private readonly IMapper _mapper;

        public PessoaServiceTest()
        {
            _pessoaRepository = new Mock<IPessoaRepository>();
            _logger = new Mock<ILogger<PessoaService>>();
            _notificacaoContext = new Mock<INotificacaoContext>();

            var mappingProfile = new AutoMapperConfig();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            _mapper = new Mapper(config);
        }

        [Fact(DisplayName = "Retornar um objeto Pessoa")]
        [Trait("Categoria", "PessoaService")]
        public async Task PessoaService_GetAllAsync_DeveRetornarUmaListaDePessoas()
        {
            // Arrange
            var listaDePessoas = new List<Pessoa> { new Pessoa { Contato = ObterContato(), Cpf = "25301948075", Endereco = ObterEndereco(), Id = 1, Nome = "Teste" } };
            var service = new PessoaService(_pessoaRepository.Object, _mapper, _logger.Object, _notificacaoContext.Object);

            _pessoaRepository.Setup(x => x.GetAllAsync(It.IsAny<string>())).ReturnsAsync(listaDePessoas);
            _mapper.Map<IEnumerable<PessoaDto>>(listaDePessoas);

            // Act
            var pessoaService = await service.GetAllAsync("25301948075");

            // Assert
            Assert.NotNull(pessoaService);
            Assert.True(pessoaService is IEnumerable<PessoaDto>);
        }

        [Fact(DisplayName = "Retornar uma Lista de Pessoas")]
        [Trait("Categoria", "PessoaService")]
        public async Task PessoaService_GetAllAsync_DeveRetornarUmObjetoPessoas()
        {
            // Arrange
            var listaDePessoas = ObterListaDePessoas();
            var service = new PessoaService(_pessoaRepository.Object, _mapper, _logger.Object, _notificacaoContext.Object);
            _pessoaRepository.Setup(x => x.GetAllAsync(It.IsAny<string>())).ReturnsAsync(listaDePessoas);

            _mapper.Map<IEnumerable<PessoaDto>>(listaDePessoas);

            // Act
            var pessoaService = await service.GetAllAsync();

            // Assert
            Assert.NotNull(pessoaService);
            Assert.True(pessoaService is IEnumerable<PessoaDto>);
            Assert.Collection(pessoaService,
                item => Assert.Equal("25301948075", item.Cpf),
                item => Assert.Equal("56484487081", item.Cpf),
                item => Assert.Equal("41697975070", item.Cpf));
        }
      

        [Fact(DisplayName = "Deletar Pessoa")]
        [Trait("Categoria", "PessoaService")]
        public async Task PessoaService_DeletarPessoa_DeveDeletarUmaPessoa()
        {
            // Arrange
            var service = new PessoaService(_pessoaRepository.Object, _mapper, _logger.Object, _notificacaoContext.Object);
            _pessoaRepository.Setup(x => x.DeleteAsync(1)).ReturnsAsync(true);
            _pessoaRepository.Setup(x => x.CpfExistAsync(1)).ReturnsAsync(true);
            // Act
            var pessoaService = await service.DeleteAsync(1);

            // Assert
            Assert.True(pessoaService);
        }

        private IEnumerable<Pessoa> ObterListaDePessoas()
        {
            var contato = ObterContato();
            var endereco = ObterEndereco();

            return new List<Pessoa> 
            { 
                new Pessoa { Cpf = "25301948075", Id = 1, Nome = "Maria", Contato = contato, Endereco = endereco },
                new Pessoa { Cpf = "56484487081", Id = 2, Nome = "João", Contato = contato, Endereco = endereco },
                new Pessoa { Cpf = "41697975070", Id = 3, Nome = "Mohamed", Contato = contato, Endereco = endereco }
            };
        }

        private Endereco ObterEndereco()
        {
            return new Endereco 
            {
                Id = 1,
                Pais = "Br",
                Estado = "MG",
                Cidade = "BH",
                Bairro = "Santa Tereza",
                Rua = "Albina",
                Numero = 54
            };
        }

        private Contato ObterContato()
        {
            return new Contato 
            { 
                Id = 123,
                Email = "teste@gmail.com",
                Telefone = "319878456521"
            };
        }

        private ResultResponse RetornarResposta(object data, string message, bool success)
        {
            return new ResultResponse { Data = data, Message = message , Success = success };
        }

        private InsertPessoaDto InsertPessoa()
        {
            var contato = ObterContato();
            var endereco = ObterEndereco();
            var contatoDto = _mapper.Map<ContatoDto>(contato);
            var enderecoDto = _mapper.Map<EnderecoDto>(endereco);

            return new InsertPessoaDto { Cpf = "25301948075", Nome = "Paul Stone", ContatoDto = contatoDto, EnderecoDto = enderecoDto };
        }
    }
}
