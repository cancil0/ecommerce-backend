﻿using Business.Abstract;
using Core.Base.Concrete;
using Core.Middleware.ExceptionMiddleware;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto.RequestDto.ApiRequestDto;
using Entities.Dto.ResponseDto.ApiResponseDto;
using Entities.Enums;

namespace Business.Concrete
{
    public class ApiService : BaseService<Api>, IApiService
    {
        private readonly IApiDal apiDal;
        public ApiService()
        {
            apiDal = Resolve<IApiDal>();
        }
        public void AddApi(string apiRoutePath)
        {
            if (string.IsNullOrEmpty(apiRoutePath) && apiRoutePath.Split("/").Length != 4)
                throw new AppException("Api.RoutePathNotFound", ExceptionTypes.NotFound.GetValue());

            Api api = new()
            {
                ApiRoute = apiRoutePath
            };

            apiDal.Insert(api);
        }

        public List<GetApiResponse> GetApis()
        {
            var apis = apiDal.GetAll();
            List<GetApiResponse> result = new();
            
            foreach (var api in apis)
            {
                result.Add(new GetApiResponse() { ApiId = api.ApiId, ApiRoute = api.ApiRoute });
            }

            return result; 
        }

        public void DeleteApi(string apiRoutePath)
        {
            var api = apiDal.GetAsNoTracking(x => x.ApiRoute == apiRoutePath);

            if (api == null)
                throw new AppException("Api.RoutePathNotFound", ExceptionTypes.NotFound.GetValue());

            apiDal.Delete(api);
        }

        public void UpdateApi(UpdateApiRequest updateApiRequest)
        {
            var api = apiDal.GetAsNoTracking(x => x.ApiRoute == updateApiRequest.OldApiPath);

            if (api == null)
                throw new AppException("Api.RoutePathNotFound", ExceptionTypes.NotFound.GetValue());

            api.ApiRoute = updateApiRequest.NewApiPath;

            apiDal.Update(api);
        }
    }
}
