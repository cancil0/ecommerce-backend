using Entities.Dto.RequestDto.MerchantRequestDto;
using Entities.Dto.ResponseDto.MerchantResponseDto;

namespace Business.Abstract
{
    public interface IMerchantService
    {
        GetMerchantResponse GetMerchant(Guid merchantId);
        void AddMerchant(AddMerchantRequest addMerchant);
        void UpdateMerchant(UpdateMerchantRequest updateMerchant);
        void DeleteMerchant(Guid merchantId);
        void GiveFeedbackToMerchant(GiveFeedbackToMerchantRequest giveFeedback);
    }
}
