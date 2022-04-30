using Core.Base.Abstract;
using Core.IoC;
using Entities.Dto.RequestDto.AddressRequestDto;
using FluentValidation;

namespace Business.Validation.DtoValidator
{
    public class CreateAddressRequestValidator : AbstractValidator<CreateAddressRequest>
    {
        private readonly ILocalizerService localizer;
        public CreateAddressRequestValidator()
        {
            localizer = Provider.Resolve<ILocalizerService>();

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
