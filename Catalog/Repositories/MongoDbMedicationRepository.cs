// using System.Threading.Tasks;

// using MongoDB.Bson;
// using MongoDB.Bson.Serialization;
// using MongoDB.Bson.Serialization.Serializers;
// using MongoDB.Driver;

// using Catalog.Controllers;
// using Catalog.Dtos;
// using Catalog.Entities;
// using Catalog.Settings;
// using Catalog.Utilities;


// namespace Catalog.Repositories
// {
//     public class MongoDbMedicationRepository : IMedicationRepository
//     {
        
//         private const string databaseName = "catalog";
//         private const string collectionName = "medications";
//         private readonly IMongoCollection<Medication> medicationCollection;

//         private readonly FilterDefinitionBuilder<UMedication> filterBuilder = Builders<Medication>.Filter;

//         public MongoDbMedicationRepository(IMongoClient mongoClient)
//         {
//             IMongoDatabase database = mongoClient.GetDatabase(databaseName);
//             medicationCollection = database.GetCollection<Medication>(collectionName);
//         }

//         public async Task CreateMedicationAsync(Medication med)
//         {
//             await medicationCollection.InsertOneAsync(med);
//         }

//         public async Task UpdateMedicationAsync(Medication med)
//         {
//             var filter = filterBuilder.Eq(existingUser => existingMedication.Id, med.Id);
//             await medicationCollection.ReplaceOneAsync(filter, med);
//         }

//         public async Task DeleteMedicationAsync(Guid id)
//         {
//            var filter = filterBuilder.Eq(med => med.MedId, id);
//            await medicationCollection.DeleteOneAsync(filter);
//         }

//         public async Task<Medication> GetMedicationAsync(Guid id)
//         {
//             var filter = filterBuilder.Eq(med => med.MedId, id);
//             return await medicationCollection.Find(filter).SingleOrDefaultAsync();
//         }

//         public async Task<IEnumerable<Medication>> GetMedicationAsync()
//         {
//             return await medicationCollection.Find(new BsonDocument()).ToListAsync();
//         }

//     }

// }
