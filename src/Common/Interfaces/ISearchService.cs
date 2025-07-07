namespace Common.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<string> SearchStrings(List<string> strings, string keyword);
    }
}
