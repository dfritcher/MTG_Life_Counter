using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq.Expressions;
using MongoDB.Driver;
using MtgLife.Shared.Entities;

namespace MtgLife.Data.Repositories
{
    public class Repository<T> where T : BaseEntity
    {
        protected List<T> ExecuteCollection(Expression<Func<T, bool>> query = null)
        {
            var collection = GetCollection();
            return query != null ? 
                collection.Find(query).ToList() : 
                collection.Find(i => true).ToList();
        }

        protected void ExecuteInsert(T objectToInsert) {
            var collection = GetCollection();
            collection.InsertOne(objectToInsert);
        }

        private static IMongoDatabase GetDatabase() {
            var server = new MongoClient(ConfigurationManager.ConnectionStrings["MtgLife"].ConnectionString);
            var database = server.GetDatabase("mtglife");
            return database;
        }
        private static IMongoCollection<T> GetCollection()
        {
            var database = GetDatabase();
            var typeName = typeof(T).Name;
            var collection = database.GetCollection<T>(typeName);
            return collection;
        }
    }
}
