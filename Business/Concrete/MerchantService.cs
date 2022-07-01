using AutoMapper;
using Business.Abstract;
using Core.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto.RequestDto.MerchantRequestDto;
using Entities.Dto.ResponseDto.MerchantResponseDto;

namespace Business.Concrete
{
    public class MerchantService : BaseService<Merchant>, IMerchantService
    {
        private readonly IMerchantDal merchantDal;
        private readonly IMapper mapper;

        public MerchantService(IMerchantDal merchantDal, 
                               IMapper mapper)
        {
            this.merchantDal = merchantDal;
            this.mapper = mapper;
        }

        public void AddMerchant(AddMerchantRequest addMerchant)
        {
            Merchant merchant = new();
            mapper.Map(addMerchant, merchant);
            merchantDal.Insert(merchant);
        }

        public void DeleteMerchant(Guid merchantId)
        {
            var merchant = merchantDal.GetMerchantById(merchantId);
            merchantDal.Delete(merchant);
        }

        public GetMerchantResponse GetMerchant(Guid merchantId)
        {
            var merchant = merchantDal.GetMerchantById(merchantId);
            return mapper.Map<GetMerchantResponse>(merchant);
        }

        public void GiveFeedbackToMerchant(GiveFeedbackToMerchantRequest giveFeedback)
        {
            var merchant = merchantDal.GetMerchantById(giveFeedback.MerchantId);
            merchant.MerchantPoint = (merchant.MerchantPoint + giveFeedback.Point) / ++merchant.FeedbackCount;
            merchantDal.Update(merchant);
        }

        public void UpdateMerchant(UpdateMerchantRequest updateMerchant)
        {
            Merchant merchant = merchantDal.GetMerchantById(updateMerchant.MerchantId);
            mapper.Map(updateMerchant, merchant);
            merchantDal.Update(merchant);
        }
    }
}
