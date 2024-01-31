using SkiServiceAPI.Data;
using SkiServiceModels.BSON.Interfaces.Base;
using SkiServiceModels.BSON.Models;

namespace SkiServiceAPI.Interfaces
{
    public interface IMongoDBContext
    {
        MongoDBCollectionWrapper<Order> Orders { get; }
        MongoDBCollectionWrapper<Priority> Priorities { get; }
        MongoDBCollectionWrapper<Service> Services { get; }
        MongoDBCollectionWrapper<State> States { get; }
        MongoDBCollectionWrapper<User> Users { get; }

        MongoDBCollectionWrapper<T> Set<T>()
            where T : class, IModel;
    }
}