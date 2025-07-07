using CsvHelper.Configuration;

namespace Common.Interfaces
{
    public interface IExcelFileService
    {
        List<T> ReadCSVToList<T>(string filePath, ClassMap<T> classMap);
    }
}
