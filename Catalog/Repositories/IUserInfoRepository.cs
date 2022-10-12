using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Catalog.Controllers;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IUserInfoRepository
    {
        IEnumerable<UserInfo> GetUserInfo();
        UserInfo GetUserInfo(Guid id);
    }
}