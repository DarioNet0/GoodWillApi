using FluentValidation;
using GoodWill.Communication.Requests.Transfer;
using GoodWill.Exception;

namespace GoodWill.Application.Validators
{
    public class BoletoValidator : AbstractValidator<RequestBoletoTransferJson>
    {
        public BoletoValidator()
        {
            RuleFor(b => b.PayerName)
                .NotEmpty().WithMessage("O nome do pagador não pode estar vazio");

            RuleFor(b => b.PayerDocument)
                .NotEmpty().WithMessage("O documento do pagador não pode estar vazio")
                .Must(BeValidDocument).WithMessage("Documento inválido");

            RuleFor(b => b.Amount)
                .GreaterThan(0).WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);

            RuleFor(b => b.CampaignId)
                .GreaterThan(0).WithMessage("ID da campanha inválido");

            RuleFor(b => b.DueDate)
                .GreaterThan(DateTime.Now.AddDays(1)).WithMessage("A data de vencimento deve ser pelo menos 1 dia após a data atual");
        }

        private bool BeValidDocument(string document)
        {
            document = new string(document.Where(char.IsDigit).ToArray());

            if (document.Length == 11)
            {
                return IsValidCpf(document);
            }
            else if (document.Length == 14)
            {
                return IsValidCnpj(document);
            }

            return false;
        }

        private bool IsValidCpf(string cpf)
        {
            if (cpf.Distinct().Count() == 1)
                return false;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCpf += digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }

        private bool IsValidCnpj(string cnpj)
        {
            if (cnpj.Distinct().Count() == 1)
                return false;

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            resto = resto < 2 ? 0 : 11 - resto;

            digito += resto.ToString();

            return cnpj.EndsWith(digito);
        }
    }
}
