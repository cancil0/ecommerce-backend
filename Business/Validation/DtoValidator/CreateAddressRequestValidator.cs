using Entities.Dto.RequestDto.AddressRequestDto;
using FluentValidation;

namespace Business.Validation.DtoValidator
{
    public class CreateAddressRequestValidator : AbstractValidator<CreateAddressRequest>
    {
        public CreateAddressRequestValidator()
        {
            RuleFor(x => x.Country)
                .NotEmpty()
                .NotNull()
                .WithMessage("Country must be filled");

            RuleFor(x => x.Province)
                .NotEmpty()
                .NotNull()
                .WithMessage("Province must be filled");

            RuleFor(x => x.District)
                .NotEmpty()
                .NotNull()
                .WithMessage("District must be filled");

            RuleFor(x => x.AddressInfo)
                .NotEmpty()
                .NotNull()
                .WithMessage("AddressInfo must be filled");

            RuleFor(x => x.AddressType)
                .NotEmpty()
                .NotNull()
                .WithMessage("AddressType must be filled");

            RuleFor(x => x.MobileNo)
                .Matches("^[0-9]{10}$")
                .When(x => !string.IsNullOrEmpty(x.MobileNo))
                .WithMessage("Please enter a proper Mobile No");
        }
    }
}
