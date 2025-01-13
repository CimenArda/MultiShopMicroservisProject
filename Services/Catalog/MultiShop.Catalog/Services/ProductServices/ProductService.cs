using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _ProductCollection;
        private readonly IMongoCollection<Category> _CategoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _CategoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _ProductCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _ProductCollection.DeleteOneAsync(x => x.ProductID == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var Product = await _ProductCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(Product);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            var values = await _ProductCollection.Find(x => true).ToListAsync();

            foreach (var item in values)
            {
                item.Category = await _CategoryCollection.Find<Category>(x => x.CategoryID == item.CategoryID).FirstAsync();
            }

            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var Product = await _ProductCollection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(Product);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductWithCategoryByCategoryIDAsync(string id)
        {
            var values = await _ProductCollection.Find(x => x.CategoryID == id).ToListAsync();

            foreach (var item in values)
            {
                item.Category = await _CategoryCollection.Find<Category>(x => x.CategoryID == item.CategoryID).FirstAsync();
            }

            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _ProductCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, value);
        }
    }
}
