using TestSalesData.Common.Models;

namespace TestSalesData.Service.DataService
{
    public interface ISalesDataService
    {
        Task<List<SalesData>> GetAllSalesDataFromCsvAsync(string csvFilePath);
    }
}
