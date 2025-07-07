using CsvHelper.Configuration;

namespace Practice_03.Models
{
    public class ProductMap : ClassMap<ProductDto>
    {
        public ProductMap()
        {
            Map(a => a.ProductId).Index(0);
            Map(a => a.Quantity).Index(1);
            Map(a => a.UnitPrice).Index(2);
        }
    }
}
