using Entities.Dto.RequestDto.ApiRequestDto;
using Entities.Dto.ResponseDto.ApiResponseDto;

namespace Business.Abstract
{
    public interface IApiService
    {
        List<GetApiResponse> GetApis();
        void AddApi(string apiRoutePath);
        void DeleteApi(string apiRoutePath);
        void UpdateApi(UpdateApiRequest updateApiRequest);
    }
}
