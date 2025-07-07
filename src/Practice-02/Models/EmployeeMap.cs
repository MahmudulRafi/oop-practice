using CsvHelper.Configuration;

namespace Practice_02.Models
{
    public class EmployeeMap : ClassMap<EmployeeDto>
    {
        public EmployeeMap()
        {
            Map(m => m.Name).Index(0);
            Map(m => m.Salary).Index(1);
        }
    }
}
