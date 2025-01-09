using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _FeatureSliderCollection;
        private readonly IMapper _mapper;

        public FeatureSliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _FeatureSliderCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await _FeatureSliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _FeatureSliderCollection.DeleteOneAsync(x => x.FeatureSliderID == id);
        }

        public async Task FeatureSliderChangeStatusToFalse(string id)
        {
            var FeatureSlider = await _FeatureSliderCollection.Find(x => x.FeatureSliderID == id).FirstOrDefaultAsync();
            FeatureSlider.Status = false;

        }

        public Task FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var FeatureSlider = await _FeatureSliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSliderDto>>(FeatureSlider);
        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var FeatureSlider = await _FeatureSliderCollection.Find(x => x.FeatureSliderID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureSliderDto>(FeatureSlider);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await _FeatureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderID == updateFeatureSliderDto.FeatureSliderID, value);
        }
    }
}
