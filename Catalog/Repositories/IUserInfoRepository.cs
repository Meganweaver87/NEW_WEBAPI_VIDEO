using System.Collections.Generic;
using System.Threading.Tasks;
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
        Task<IEnumerable<UserInfo>> GetUserInfoAsync();
        Task<UserInfo> GetUserInfoAsync(Guid id);

        Task CreateUserInfoAsync(UserInfo userInfo);

        Task UpdateUserInfoAsync(UserInfo userInfo);

        Task DeleteUserInfoAsync(Guid id);

    }
}