using MongoDB.Driver;

namespace MongoExample.Web.Storage
{
    public class MongoConnection
    {
        public static MongoClient Client { get; private set; }
        public static string DatabaseName { get; private set; }

        public static MongoClient Configure(string connectionString, string databaseName)
        {
            Client = new MongoClient(connectionString);
            DatabaseName = databaseName;

            return Client;
        }

        public static MongoCollection<T> GetCollection<T>(string collectionName)
        {
            return Client.GetServer().GetDatabase(DatabaseName).GetCollection<T>(collectionName);
        }
    }
}