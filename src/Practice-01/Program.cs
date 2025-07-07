using Common.Interfaces;
using Common.Services;

List<string> names = ["Tareq", "Afsana", "Imtiaz", "Pulok", "Robin", "Samia", "Rupok"];

string searchString = Console.ReadLine()!;

ISearchService searchService = new SearchService();

var searchResponse = searchService.SearchStrings(names, searchString);

Console.WriteLine(string.Join(',', searchResponse));