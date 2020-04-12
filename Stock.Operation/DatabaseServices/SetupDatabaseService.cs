using MongoDB.Driver;
using Stock.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock.Operation.DatabaseServices
{
    public class SetupDatabaseService
    {
        public string CreateDbService(IStockDatabaseSettings settings,<T> data)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            product = database.GetCollection<Product>(settings.ProductCollectionName);

        }
    }
}
