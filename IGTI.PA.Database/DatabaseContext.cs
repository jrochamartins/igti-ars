using IGTI.PA.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

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
        }

        internal IMongoCollection<Prospect> Prospects => _database.GetCollection<Prospect>(nameof(Prospects).ToLower());

        private static IMongoDatabase DatabaseFactory(string databaseConnection, string databaseName) =>
            new MongoClient(databaseConnection).GetDatabase(databaseName);

        //private static void RegisterClassMap()
        //{
        //    BsonClassMap.RegisterClassMap<Prospect>(_ =>
        //    {
        //        _.SetIgnoreExtraElements(true);
        //        _.AutoMap();
        //    });
        //}
    }
}
