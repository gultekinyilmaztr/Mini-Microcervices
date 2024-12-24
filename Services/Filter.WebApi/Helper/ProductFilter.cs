using System.Text.Json.Serialization;

namespace Filter.WebApi.Helper
{
    public class ProductFilter
    {
        [JsonPropertyName("productName")]
        public string Name { get; set; }

        [JsonPropertyName("subCategoryId")]
        public Guid? SubCategoryId { get; set; }
    }

}
