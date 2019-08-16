using IGTI.PA.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Driver;
using System.Security.Authentication;

namespace IGTI.PA.Database
{
    public class DatabaseContext
    {
        private readonly DatabaseContextOptions _options;
        private readonly IMongoDatabase _database;

        public DatabaseContext(
            IOptionsMonitor<DatabaseContextOptions> optionsAccessor)
        {   
            _options = optionsAccessor.CurrentValue;
            _database = DatabaseFactory(_options.DatabaseConnection, _options.DatabaseName);
            RegisterClassMap();
        }

        internal IMongoCollection<Prospect> Prospects => _database.GetCollection<Prospect>(nameof(Prospects).ToLower());

        private static IMongoDatabase DatabaseFactory(string databaseConnection, string databaseName)
        {
            //var client = new MongoClient("mongodb://paArsUser:$[password]@pa-ars-393ax.azure.mongodb.net:27017/PA-ARS?authSource=admin");
            var client = new MongoClient(databaseConnection);
            return client.GetDatabase(databaseName);
        }

        private static void RegisterClassMap()
        {
            BsonClassMap.RegisterClassMap<Prospect>(cm =>
            {
                cm.AutoMap();
                //cm.SetIgnoreExtraElements(true);
            });
        }
    }
}
