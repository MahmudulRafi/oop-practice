using Practice_03.Models;

namespace Practice_03.Helpers
{
    public static class ProductHelper
    {
        public static bool CheckDuplicateItems(this List<ProductDto> productLists)
        {
            var duplicateIds = productLists
            .GroupBy(p => p.ProductId)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();

            if (duplicateIds.Any())
            {
                Console.WriteLine("Duplicate item IDs found:");
                
                foreach (var id in duplicateIds)
                    Console.WriteLine($"- {id}");
                
                return false;
            }

            return true;
        }
    }
}
