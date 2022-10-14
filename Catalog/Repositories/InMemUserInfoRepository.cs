using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using MongoDB.Driver;

using Catalog.Controllers;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Settings;
using Catalog.Utilities;


namespace Catalog.Repositories
{

    public class InMemUserInfoRepository : IUserInfoRepository
    {
        private readonly List<UserInfo> users = new()
        {

            new UserInfo { Id = Guid.NewGuid(), Name = "Joe", Dob = Convert.ToDateTime("1980-12-05"), CreatedDate = DateTimeOffset.UtcNow },
            new UserInfo { Id = Guid.NewGuid(), Name = "Jane", Dob = Convert.ToDateTime("1990-05-10"), CreatedDate = DateTimeOffset.UtcNow },
            new UserInfo { Id = Guid.NewGuid(), Name = "Jimmy", Dob = Convert.ToDateTime("1995-10-20"), CreatedDate = DateTimeOffset.UtcNow }
            
        };
        
        public async Task<UserInfo> GetUserInfoAsync(Guid id)
        {
            var userInfo = users.Where(userInfo => userInfo.Id == id).SingleOrDefault();
            return await Task.FromResult(userInfo);
        }

        public async Task<IEnumerable<UserInfo>> GetUserInfoAsync()
        {
            //throw new NotImplementedException();
            return await Task.FromResult(users);
        }

        public async Task CreateUserInfoAsync(UserInfo userInfo)
        {
            users.Add(userInfo);
            await Task.CompletedTask;
        }

        public async Task UpdateUserInfoAsync(UserInfo userInfo)
        {
            var index = users.FindIndex(existingUser => existingUser.Id == userInfo.Id);
            users[index] = userInfo;
            await Task.CompletedTask;
        }

        public async Task DeleteUserInfoAsync(Guid id)
        {
            var index = users.FindIndex(existingUser => existingUser.Id == id);
            users.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}
