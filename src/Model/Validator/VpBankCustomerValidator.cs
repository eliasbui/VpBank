using FluentValidation;
using Model.Request;

namespace Model.Validator;

public class VpBankCustomerValidator : AbstractValidator<CreateVpBankCustomerModel>
{
    public VpBankCustomerValidator()
    {
        RuleFor(x => x.CustomerName)
            .NotEmpty().WithMessage("CustomerName is required")
            .Length(10, 100).WithMessage("CustomerName must be between 10 and 100 characters")
            .Matches("^[a-zA-Z ]").WithMessage("CustomerName should only contain letters and spaces.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("PhoneNumber is required")
            .Matches("^0[0-9]{9}$").WithMessage("PhoneNumber must start with '0' and have 10 digits");

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required")
            .Matches("^[a-zA-Z ]+$").WithMessage("Country should only contain letters and spaces.");

        RuleFor(x => x.LoanPayMust)
            .NotEmpty().WithMessage("LoanPayMust is required")
            .GreaterThanOrEqualTo("0").WithMessage("LoanPayMust must be greater than or equal to 0")
            .LessThanOrEqualTo("100000000").WithMessage("LoanPayMust must not exceed 100,000,000 VND");

        RuleFor(x => x.GiveSalaryType)
            .NotEmpty().WithMessage("GiveSalaryType is required")
            .Must(x => x == "Tiền Mặt" || x == "Chuyển khoản")
            .WithMessage("GiveSalaryType must be 'Tiền Mặt' or 'Chuyển khoản'");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email must be a valid email address");
    }
}