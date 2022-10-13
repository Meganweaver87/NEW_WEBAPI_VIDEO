using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Catalog.Controllers;
using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IUserInfoRepository
    {
        IEnumerable<UserInfo> GetUserInfo();
        UserInfo GetUserInfo(Guid id);

        void CreateUserInfo(UserInfo userInfo);

        void UpdateUserInfo(UserInfo userInfo);

        void DeleteUserInfo(Guid id);

    }
}