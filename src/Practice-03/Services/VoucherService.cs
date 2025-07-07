using Practice_03.Models;

namespace Practice_03.Services
{
    public class VoucherService : IVoucherService
    {
        public List<string> PrepareVoucherLines(List<ProductDto> productLists)
        {
            double grandTotal = 0;

            int totalQty = 0;

            var voucherLines = new List<string>
            {
                "Item id\t\tQty\tunit price\ttotal"
            };

            foreach (var item in productLists)
            {
                double total = item.Quantity * item.UnitPrice;
                grandTotal += total;
                totalQty += item.Quantity;

                voucherLines.Add($"{item.ProductId}\t{item.Quantity}\t{item.UnitPrice}\t\t{total}");
            }

            double vat = grandTotal * 0.05;

            double netTotal = grandTotal + vat;

            voucherLines.Add($"\nTotal\t\t{totalQty}\tGrand total \t{grandTotal}");
            voucherLines.Add($"VAT (5%)\t\t\t\t{vat}");
            voucherLines.Add($"Net total\t\t\t\t{netTotal}");

            return voucherLines;
        }
        public async Task SaveVoucherToFileAsync(string fileDirectory, string fileNameWithExtension, List<string> voucherLines)
        {
            var outputDir = Path.Combine(fileDirectory);

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            string outputPath = Path.Combine(outputDir, fileNameWithExtension);

            try
            {
                await File.WriteAllLinesAsync(outputPath, voucherLines);
                Console.WriteLine("File saved: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to file: " + ex.Message);
            }
        }
    }
}
