using AutoMapper;
using crud_pessoa.api.Dtos;
using crud_pessoa.api.Entities;

namespace crud_pessoa.api.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<EnderecoDto, Endereco>().ReverseMap();
            CreateMap<ContatoDto, Contato>().ReverseMap();

            CreateMap<InsertPessoaDto, Pessoa>()
                .ForMember(dest => dest.Contato, from => from.MapFrom(x => x.ContatoDto))
                .ForMember(dest => dest.Endereco, from => from.MapFrom(x => x.EnderecoDto));

            CreateMap<Pessoa,InsertPessoaDto>()
                .ForMember(dest => dest.ContatoDto, from => from.MapFrom(x => x.Contato))
                .ForMember(dest => dest.EnderecoDto, from => from.MapFrom(x => x.Endereco));

            CreateMap<Pessoa, PessoaDto>()
                .ForMember(dest => dest.ContatoDto, from => from.MapFrom(x => x.Contato))
                .ForMember(dest => dest.EnderecoDto, from => from.MapFrom(x => x.Endereco));

            CreateMap<PessoaDto, Pessoa>()
                .ForMember(dest => dest.Contato, from => from.MapFrom(x => x.ContatoDto))
                .ForMember(dest => dest.Endereco, from => from.MapFrom(x => x.EnderecoDto));
        }
    }
}
