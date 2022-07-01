using Core.Abstract;
using Entities.Dto.RequestDto.ProductDetailRequestDto;
using FluentValidation;

namespace Business.Validation.DtoValidator
{
    public class AddProductDetailRequestValidator : AbstractValidator<AddProductDetailRequest>
    {
        public AddProductDetailRequestValidator(ILocalizerService localizer)
        {
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
