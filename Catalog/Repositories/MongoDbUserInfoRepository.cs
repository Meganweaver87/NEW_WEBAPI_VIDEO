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

        public void CreateUserInfoAsync(UserInfo userInfo)
        {
            usersCollection.InsertOne(userInfo);
        }

        public void UpdateUserInfoAsync(UserInfo userInfo)
        {
            var filter = filterBuilder.Eq(existingUser => existingUser.Id, userInfo.Id);
            usersCollection.ReplaceOne(filter, userInfo);
        }

        public void DeleteUserInfoAsync(Guid id)
        {
           var filter = filterBuilder.Eq(userInfo => userInfo.Id, id);
           usersCollection.DeleteOne(filter);
        }

        public UserInfo GetUserInfoAsync(Guid id)
        {
            var filter = filterBuilder.Eq(userInfo => userInfo.Id, id);
            return usersCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<UserInfo> GetUserInfo()
        {
            return usersCollection.Find(new BsonDocument()).ToList();
        }

    }

}
