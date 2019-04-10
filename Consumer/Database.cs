using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace Resource
{
    class Database
    {
        private MongoClient Client;

        private IMongoDatabase Mongodb;

        public Database Connect()
        {
            this.Client = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING"));
            return this;
        }

        public Database From(string database)
        {
            this.Mongodb = Client.GetDatabase(database);
            return this;
        }

        public void Create(string collection, string key, string value)
        {

            var document = this.Mongodb.GetCollection<BsonDocument>(collection);
            BsonDocument item = new BsonDocument();
            item.Add(new BsonElement(key, value));
            document.InsertOne(item);

        }

    }
}
