using Core.Abstract;
using Entities.Dto.RequestDto.AddressRequestDto;
using FluentValidation;

namespace Business.Validation.DtoValidator
{
    public class CreateAddressRequestValidator : AbstractValidator<CreateAddressRequest>
    {
        public CreateAddressRequestValidator(ILocalizerService localizer)
        {
            RuleFor(x => x.Country)
                .NotNull()
                .WithMessage("CreateAddressRequestValidator.CountryNotNull");

            RuleFor(x => x.Province)
                .NotNull()
                .WithMessage("CreateAddressRequestValidator.ProvinceNotNull");

            RuleFor(x => x.District)
                .NotNull()
                .WithMessage("CreateAddressRequestValidator.DistrictNotNull");

            RuleFor(x => x.AddressInfo)
                .NotNull()
                .WithMessage("CreateAddressRequestValidator.AddressInfoNotNull");

            RuleFor(x => x.AddressType)
                .NotNull()
                .WithMessage("CreateAddressRequestValidator.AddressTypeNotNull");

            RuleFor(x => x.MobileNo)
                .Matches("^[0-9]{10}$")
                .When(x => !string.IsNullOrEmpty(x.MobileNo))
                .WithMessage("CreateAddressRequestValidator.MobileNo");
        }
    }
}
