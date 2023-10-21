using FluentValidation;
using Model.Request;

namespace Model.Validator;

public class EmailLogValidator : AbstractValidator<CreateLogEmailModel>
{
    public EmailLogValidator()
    {
        RuleFor(x=>x.VpBankCustomerId).NotEmpty().WithMessage("VpBankCustomerId is required");
        RuleFor(x => x.CreatedDate).NotEmpty().WithMessage("CreatedDate is required");
    }
}