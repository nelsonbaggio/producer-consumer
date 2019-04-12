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
            this.Client = new MongoClient("mongodb://127.0.0.1:27017");
            return this;
        }

        public Database From(string database)
        {
            this.Mongodb = Client.GetDatabase(database);
            return this;
        }

        public void Create(string collection, BsonDocument book)
        {

            var document = this.Mongodb.GetCollection<BsonDocument>(collection);
            document.InsertOne(book);

        }

    }
}
