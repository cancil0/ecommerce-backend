namespace Entities.Dto.RequestDto.MerchantRequestDto
{
    public class GiveFeedbackToMerchantRequest
    {
        public Guid MerchantId { get; set; }
        public Guid UserId { get; set; }
        public decimal Point { get; set; }
    }
}
