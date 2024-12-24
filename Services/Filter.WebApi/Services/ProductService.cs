using Contracts.Product;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Elastic.Clients.Elasticsearch;
using Filter.WebApi.Services;
using Filter.WebApi.Models;

public class ProductService : IProductService
{
    private readonly ElasticsearchClient _client;
    private string _indexName;

    public ProductService(ElasticsearchClient client, IConfiguration configuration)
    {
        _client = client;
        _indexName = configuration["Elasticsearch:Index"] ?? "";
    }

    public async Task<IEnumerable<CreatedProductResponse>> GetFilteredProductsAsync(string? name, Guid? subCategoryId, CancellationToken cancellationToken)
    {
        var mustQueries = new List<Query>();

        if (subCategoryId.HasValue)
        {
            mustQueries.Add(new MatchQuery(new Field("subCategoryId"))
            {
                Query = subCategoryId.ToString()
            });
        }

        if (!string.IsNullOrEmpty(name))
        {
            mustQueries.Add(new MatchQuery(new Field("name"))
            {
                Query = name
            });
        }

        var boolQuery = new BoolQuery
        {
            Must = mustQueries
        };

        var searchResponse = await _client.SearchAsync<Product>(s => s
            .Query(q => q.Bool(boolQuery))
            .Size(1000), cancellationToken);

        if (!searchResponse.IsValidResponse)
        {
            throw new Exception("Error fetching filtered products from Elasticsearch");
        }

        return searchResponse.Documents.Select(d => new CreatedProductResponse
        {
            Id = d.Id,
            Name = d.Name,
            Description = d.Description,
            Price = d.Price,
            StockQuantity = d.StockQuantity,
            IsNew = d.IsNew,
            IsAvailable = d.IsAvailable,
            Condition = d.Condition,
            SubCategoryId = d.SubCategoryId,
            Manufacturer = d.Manufacturer,
            IsFeatured = d.IsFeatured,
            DiscountPrice = d.DiscountPrice,
            ViewCount = d.ViewCount,
            BrandId = d.BrandId,
            ModelId = d.ModelId
        });
    }
}