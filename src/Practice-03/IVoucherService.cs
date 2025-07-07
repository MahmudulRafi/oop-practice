using Practice_03.Models;

namespace Practice_03
{
    public interface IVoucherService
    {
        List<string> PrepareVoucherLines(List<ProductDto> productLists);
        Task SaveVoucherToFileAsync(string fileDirectory, string fileNameWithExtension, List<string> voucherLines);
    }
}
