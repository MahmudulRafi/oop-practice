using Common.Interfaces;

namespace Common.Services
{
    public class SearchService : ISearchService
    {
        public IEnumerable<string> SearchStrings(List<string> strings, string keyword)
        {
            return strings.Where(name => name.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }
    }
}
