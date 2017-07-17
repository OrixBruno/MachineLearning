using AspNetAPiRestfull.IServices;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetAPiRestfull.Services
{
    public abstract class DataAccess<TCLASSE,TPrimaryKey>
    {
        private MongoClient _client;
        private MongoServer _server;
        public string _collection;
        public IMongoDatabase _db;
        public MongoDatabase _db2;

        public DataAccess(string collection)
        {
            _client = new MongoClient("mongodb://brunosilva:dadinha@ds028310.mlab.com:28310/machinelearning");
            _db = _client.GetDatabase("machinelearning");
            CollectionExist(collection);
            _collection = collection;
        }
        private void CollectionExist(string collection)
        {
            var filter = new BsonDocument("DatePick", collection);
            var collectionCursor = _db.ListCollections(new ListCollectionsOptions { Filter = filter });
            var exist = collectionCursor.Any();
            if (!exist)
            {
                _db.CreateCollection(collection);
            }
        }
        //Metodos Genericos
        public async Task<List<TCLASSE>> GetLista()
        {
            return await _db.GetCollection<TCLASSE>(_collection).Find(Builders<TCLASSE>.Filter.Empty).ToListAsync();
        }
        public async Task<TCLASSE> Create(TCLASSE p)
        {
            await _db.GetCollection<TCLASSE>(_collection).InsertOneAsync(p);
            return p;
        }        
        public abstract Task<TCLASSE> Get(TPrimaryKey id);
        public abstract Task Update(TPrimaryKey id, TCLASSE p);
        public abstract Task Remove(TPrimaryKey id);
    }
}