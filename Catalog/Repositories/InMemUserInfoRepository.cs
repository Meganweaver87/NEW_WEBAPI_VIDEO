using System.Collections.Generic;
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
        
        public UserInfo GetUserInfo(Guid id)
        {
            return users.Where(users => users.Id == id).SingleOrDefault();
        }

        public IEnumerable<UserInfo> GetUserInfo()
        {
            //throw new NotImplementedException();
            return users;
        }

        public void CreateUserInfo(UserInfo userInfo)
        {
            users.Add(userInfo);
        }

        public void UpdateUserInfo(UserInfo userInfo)
        {
            var index = users.FindIndex(existingUser => existingUser.Id == userInfo.Id);
            users[index] = userInfo;
        }

        public void DeleteUserInfo(Guid id)
        {
            var index = users.FindIndex(existingUser => existingUser.Id == id);
            users.RemoveAt(index);
        }
    }
}
