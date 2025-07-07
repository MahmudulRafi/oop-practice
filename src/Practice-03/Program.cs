using Common.Interfaces;
using Common.Services;
using Practice_03;
using Practice_03.Helpers;
using Practice_03.Models;
using Practice_03.Services;

IExcelFileService excelFileService = new ExcelFileService();

string filePath = Path.Combine("Files", "groceryitems.csv");

var productLists = excelFileService.ReadCSVToList<ProductDto>(filePath, new ProductMap());

var containsDuplicate = productLists.CheckDuplicateItems();

if (containsDuplicate) return;

IVoucherService voucherService = new VoucherService();

var voucherLines = voucherService.PrepareVoucherLines(productLists);

foreach (var line in voucherLines)
    Console.WriteLine(line);

await voucherService.SaveVoucherToFileAsync("Files", "voucher.txt", voucherLines);