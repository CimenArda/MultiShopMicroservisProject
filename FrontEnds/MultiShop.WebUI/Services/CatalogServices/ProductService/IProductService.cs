using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductService
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();

       Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryByCategoryIDAsync(string id);


    }
}
