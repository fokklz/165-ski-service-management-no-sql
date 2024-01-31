using AutoMapper;
using MongoDB.Driver;
using SkiServiceAPI.Interfaces;
using SkiServiceModels.BSON.Interfaces.Base;
using SkiServiceModels.BSON.Models;

namespace SkiServiceAPI.Data
{
    public class MongoDBContext : IMongoDBContext
    {

        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        private readonly IMapper _mapper;

        public IMongoClient Client { get { return _client; } }

        public MongoDBContext(IConfiguration configuration, IMapper mapper)
        {
            var mongoConfig = configuration.GetSection("Database").GetSection("MongoDB");

            _client = new MongoClient(mongoConfig.GetValue("URL", "mongodb://localhost:27017")!);
            _database = _client.GetDatabase(mongoConfig.GetValue("Name", "skiservice-api"));

            _mapper = mapper;
        }

        public MongoDBCollectionWrapper<User> Users => new(_database, _mapper);
        public MongoDBCollectionWrapper<Order> Orders => new(_database, _mapper);
        public MongoDBCollectionWrapper<Priority> Priorities => new(_database, _mapper);
        public MongoDBCollectionWrapper<State> States => new(_database, _mapper);
        public MongoDBCollectionWrapper<Service> Services => new(_database, _mapper);


        /// <summary>
        /// Dynamically load a Collection wrapper based on a Type
        /// </summary>
        /// <typeparam name="T">Target Type to get the Wrapper for</typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Thrown when the type has no Wrapper declaration inside this class</exception>
        public MongoDBCollectionWrapper<T> Set<T>()
            where T : class, IModel
        {
            var propertyInfo = GetType()
                                .GetProperties()
                                .FirstOrDefault(p => p.PropertyType == typeof(MongoDBCollectionWrapper<T>));

            if (propertyInfo != null)
            {
                return (MongoDBCollectionWrapper<T>)propertyInfo.GetValue(this)!;
            }
            else
            {
                // will only every throw if a undeclared collection is getting received
                throw new InvalidOperationException($"No collection wrapper found for type {typeof(T).Name}");
            }
        }

    }
}
