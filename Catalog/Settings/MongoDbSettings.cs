using MongoDB.Driver;

using Catalog.Controllers;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Catalog.Utilities;
using Catalog.Settings;

namespace Catalog.Settings
{
    public class MongoDbSettings
    {
        public string Host {get; set;}
        public int Port {get; set;}

        public string ConnectionString 
        {
            get
            {
                return $"mongodb://{Host}:{Port}";
            }
        }
    }
}