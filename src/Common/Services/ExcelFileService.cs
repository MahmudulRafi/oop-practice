using Common.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Common.Services
{
    public class ExcelFileService : IExcelFileService
    {
        public List<T> ReadCSVToList<T>(string filePath, ClassMap<T> classMap)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                    throw new ArgumentNullException(nameof(filePath), "Filepath is null");

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                    Delimiter = "\t"
                };

                using var streamReader = new StreamReader(filePath);

                using var csv = new CsvReader(streamReader, config);

                csv.Context.RegisterClassMap(classMap);

                return new List<T>(csv.GetRecords<T>());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occured. Message : {ex.Message}");
            }

            return [];
        }
    }
}
