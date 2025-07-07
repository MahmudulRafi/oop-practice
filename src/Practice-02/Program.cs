using Common.Interfaces;
using Common.Services;
using Practice_02.Models;

IExcelFileService excelFileService = new ExcelFileService();

string filePath = Path.Combine("Files", "salarysheet.csv");

var employeeLists = excelFileService.ReadCSVToList<EmployeeDto>(filePath, new EmployeeMap());

var employeeOfMaxSalary = employeeLists.MaxBy(a => a.Salary);

var employeeOfMinSalary = employeeLists.MinBy(a => a.Salary);

Console.WriteLine($"Max: {employeeOfMaxSalary?.Name} {employeeOfMaxSalary?.Salary}");

Console.WriteLine($"Min: {employeeOfMinSalary?.Name} {employeeOfMinSalary?.Salary}");