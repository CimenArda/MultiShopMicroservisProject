using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _ProductCollection;
        private readonly IMongoCollection<Category> _CategoryCollection;
        private readonly IMongoCollection<Brand> _BrandCollection;

        public StatisticService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _CategoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _BrandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
        }

        public async Task<long> GetBrandCount()
        {
            return await _BrandCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
        }

        public async Task<long> GetCategoryCount()
        {
            return await _CategoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y =>
                                                                  y.ProductName).Exclude("ProductID");
            var product = await _ProductCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();

            return product.GetValue("ProductName").AsString;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y =>
                                                                  y.ProductName).Exclude("ProductID");
            var product = await _ProductCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();

            return product.GetValue("ProductName").AsString;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var pipeline = new BsonDocument[]
            {
            new BsonDocument("$group", new BsonDocument
            {
                { "_id", BsonNull.Value },
                { "averagePrice", new BsonDocument("$avg", "$ProductPrice") }
              })
              };

            var result = await _ProductCollection.AggregateAsync<BsonDocument>(pipeline);
            var value = result.FirstOrDefault().GetValue("averagePrice", decimal.Zero).AsDecimal;
            return value;
        }

        public async Task<long> GetProductCount()
        {
            return await _ProductCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);

        }
    }
}
