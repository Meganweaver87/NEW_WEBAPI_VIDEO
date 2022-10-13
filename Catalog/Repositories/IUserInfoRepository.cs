using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using MongoDB.Driver;

using Catalog.Controllers;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Settings;
using Catalog.Utilities;

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