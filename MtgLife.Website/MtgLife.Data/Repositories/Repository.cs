using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq.Expressions;
using MongoDB.Bson;
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

        protected void ExecuteReplace(Expression<Func<T, bool>> query, T objectToInsert)
        {
            var collection = GetCollection();
            collection.ReplaceOne(query, objectToInsert);
        }

        protected void ExecuteUpdate(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            var collection = GetCollection();
            collection.UpdateOne(filter, update);
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
