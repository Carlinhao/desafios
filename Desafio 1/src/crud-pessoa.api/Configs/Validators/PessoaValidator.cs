using crud_pessoa.api.Dtos;
using FluentValidation;

namespace crud_pessoa.api.Configs.Validators
{
    public class PessoaValidator : AbstractValidator<PessoaDto>
    {
        private const string NomeErrorMessage = "Nome não pode ser vazio ou nulo";
        private const string CpfErrorMessage = "Cpf não pode ser vazio ou nulo";
        private const string CpfNumeroErrorMessage = "Numero Cpf deve possuir 11 dígitos";
        private const string ContatoDtoErroMessage = "Contato não pode ser vazio ou nulo";
        private const string EnderecoDtoErroMessage = "Endereço não pode ser vazio ou nulo";

        public PessoaValidator()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage(NomeErrorMessage)
                .NotEmpty()
                .WithMessage(NomeErrorMessage);

            RuleFor(x => x.Cpf)
                .NotNull()
                .WithMessage(CpfErrorMessage)
                .NotEmpty()
                .WithMessage(CpfErrorMessage)
                .MinimumLength(11)
                .WithMessage(CpfNumeroErrorMessage)
                .MaximumLength(11)
                .WithMessage(CpfNumeroErrorMessage);

            RuleFor(x => x.ContatoDto)
                .NotNull()
                .WithMessage(ContatoDtoErroMessage)
                .NotEmpty()
                .WithMessage(ContatoDtoErroMessage);

            RuleFor(x => x.EnderecoDto)
                .NotNull()
                .WithMessage(EnderecoDtoErroMessage)
                .NotEmpty()
                .WithMessage(EnderecoDtoErroMessage);
        }
    }
}
