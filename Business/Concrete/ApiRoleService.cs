﻿using Business.Abstract;
using Core.Attributes;
using Core.Concrete;
using Core.ExceptionHandler;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto.RequestDto.ApiRoleRequestDto;
using Entities.Dto.ResponseDto.ApiRoleResponse;
using Entities.Enums;
using Microsoft.Extensions.Caching.Memory;

namespace Business.Concrete
{
    public class ApiRoleService : BaseService<ApiRole>, IApiRoleService
    {
        private readonly IApiDal apiDal;
        private readonly IRoleDal roleDal;
        private readonly IApiRoleDal apiRoleDal;
        private readonly IMemoryCache cache;
        public ApiRoleService(IApiRoleDal apiRoleDal, 
                              IApiDal apiDal, 
                              IRoleDal roleDal, 
                              IMemoryCache cache)
        {
            this.apiRoleDal = apiRoleDal;
            this.apiDal = apiDal;
            this.roleDal = roleDal;
            this.cache = cache;
        }

        [UnitofWork]
        public void AddApiRole(ApiRoleRequest apiRoleRequest)
        {
            var api = apiDal.GetById(apiRoleRequest.ApiId);

            if (api == null)
                throw new AppException("Api.NotFound", ExceptionTypes.NotFound.GetValue());

            var role = roleDal.GetById(apiRoleRequest.RoleId);

            if (role == null)
                throw new AppException("Role.NotFound", ExceptionTypes.NotFound.GetValue());

            ApiRole apiRole = new()
            {
                ApiId = apiRoleRequest.ApiId,
                RoleId = apiRoleRequest.RoleId
            };

            apiRoleDal.Insert(apiRole);

            cache.Remove(CacheTypes.ApiRoleCache.GetValue());
        }

        [UnitofWork]
        public void DeleteApiRole(ApiRoleRequest apiRoleRequest)
        {
            var apiRole = apiRoleDal.Get(x => x.RoleId == apiRoleRequest.RoleId && x.ApiId == apiRoleRequest.ApiId);

            if(apiRole == null)
                throw new AppException("ApiRole.NotFound", ExceptionTypes.NotFound.GetValue());

            apiRoleDal.Delete(apiRole);

            cache.Remove(CacheTypes.ApiRoleCache.GetValue());
        }

        public List<GetApiRoleResponse> GetApiRoles()
        {
            if(cache.TryGetValue(CacheTypes.ApiRoleCache.GetValue(), out List<GetApiRoleResponse> apiRoles))
            {
                return apiRoles;
            }

            apiRoles = new();
            var allApiRoles = apiRoleDal.GetAllWithInclude(x => x.Role, x => x.Api);

            foreach (var apiRole in allApiRoles)
            {
                apiRoles.Add(new GetApiRoleResponse()
                {
                    RoleId = apiRole.RoleId,
                    ApiId = apiRole.ApiId,
                    RoleName = apiRole.Role.RoleName,
                    ApiRoutePath = apiRole.Api.ApiRoute
                });
            }

            cache.Set(CacheTypes.ApiRoleCache.GetValue(), apiRoles);

            return apiRoles;
        }
    }
}
