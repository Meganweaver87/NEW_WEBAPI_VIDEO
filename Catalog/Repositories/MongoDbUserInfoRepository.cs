using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

using Catalog.Controllers;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Settings;
using Catalog.Utilities;


namespace Catalog.Repositories
{
    public class MongoDbUserInfoRepository : IUserInfoRepository
    {
        
        private const string databaseName = "catalog";
        private const string collectionName = "users";
        private readonly IMongoCollection<UserInfo> usersCollection;

        private readonly FilterDefinitionBuilder<UserInfo> filterBuilder = Builders<UserInfo>.Filter;

        public MongoDbUserInfoRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            usersCollection = database.GetCollection<UserInfo>(collectionName);
        }

        public async Task CreateUserInfoAsync(UserInfo userInfo)
        {
            await usersCollection.InsertOneAsync(userInfo);
        }

        public async Task UpdateUserInfoAsync(UserInfo userInfo)
        {
            var filter = filterBuilder.Eq(existingUser => existingUser.Id, userInfo.Id);
            await usersCollection.ReplaceOneAsync(filter, userInfo);
        }

        public async Task DeleteUserInfoAsync(Guid id)
        {
           var filter = filterBuilder.Eq(userInfo => userInfo.Id, id);
           await usersCollection.DeleteOneAsync(filter);
        }

        public async Task<UserInfo> GetUserInfoAsync(Guid id)
        {
            var filter = filterBuilder.Eq(userInfo => userInfo.Id, id);
            return await usersCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<UserInfo>> GetUserInfoAsync()
        {
            return await usersCollection.Find(new BsonDocument()).ToListAsync();
        }

    }

}
