using Core.Abstract;
using Core.IoC;
using Entities.Dto.RequestDto.ProductDetailRequestDto;
using FluentValidation;

namespace Business.Validation.DtoValidator
{
    public class AddProductDetailRequestValidator : AbstractValidator<AddProductDetailRequest>
    {
        private readonly ILocalizerService localizer;
        public AddProductDetailRequestValidator()
        {
            localizer = Provider.Resolve<ILocalizerService>();

            RuleFor(x => x.ProductId)
                .Must(x => x != Guid.Empty)
                .WithMessage(localizer.GetResource("ProductDetail.ChooseProductToAdd"));

            RuleFor(x => x.MerchantId)
                .Must(x => x != Guid.Empty)
                .WithMessage(localizer.GetResource("ProductDetail.ChooseMerchantToAdd"));

            RuleFor(x => x)
                .Must(x => x.Count > 0)
                .WithMessage(localizer.GetResource("ProductDetail.CheckCount"));
        }
    }
}
