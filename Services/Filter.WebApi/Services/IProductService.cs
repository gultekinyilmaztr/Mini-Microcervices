using Contracts.Product;

namespace Filter.WebApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<CreatedProductResponse>> GetFilteredProductsAsync(string? name, Guid? subCategoryId, CancellationToken cancellationToken);
    }
}
