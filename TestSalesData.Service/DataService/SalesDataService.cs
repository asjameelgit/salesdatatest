using System.Text;
using TestSalesData.Common.Models;
using Microsoft.Extensions.Logging;

namespace TestSalesData.Service.DataService
{
    public class SalesDataService(ILogger<SalesDataService> logger) : ISalesDataService
    {
        public async Task<List<SalesData>> GetAllSalesDataFromCsvAsync(string csvFilePath)
        {
            logger.LogInformation($"in GetAllSalesDataFromCsvAsync with Path {csvFilePath}");
            try
            {
                var result = new List<SalesData>();
                var lines = await File.ReadAllLinesAsync(csvFilePath,encoding:  Encoding.ASCII).ConfigureAwait(false);
                foreach (var line in lines.Skip(1))
                {
                    var columns = line.Split(',');
                    var salesData = new SalesData();

                    decimal UnitsSold = decimal.Zero;
                    decimal MfgPrice = decimal.Zero;
                    decimal SalesPrice = decimal.Zero;

                    decimal.TryParse(columns[4], out UnitsSold);
                    decimal.TryParse(string.IsNullOrEmpty(columns[5]) ? "0.00" : columns[5].Trim().Replace(" ", "").Replace("?", ""), out MfgPrice);
                    decimal.TryParse(string.IsNullOrEmpty(columns[6]) ? "0.00" : columns[6].Trim().Replace(" ", "").Replace("?", ""), out SalesPrice);

                    salesData.Segment = columns[0].Trim();
                    salesData.Country = columns[1].Trim();
                    salesData.Product = columns[2].Trim();
                    salesData.Discount = string.IsNullOrEmpty(columns[3]) ? "None" : columns[3].Trim();
                    salesData.UnitsSold = UnitsSold;
                    salesData.MfgPrice = MfgPrice; 
                    salesData.SalesPrice = SalesPrice;
                    salesData.SalesDate = string.IsNullOrEmpty(columns[7]) ? null : DateTime.ParseExact(columns[7].Trim(), "MM/dd/yyyy", null);
                    result.Add(salesData);
                }
                return result;
            }
            catch (Exception ex) 
            {
                logger.LogError($"Error in GetAllSalesDataFromCsvAsync with Path {csvFilePath} - {ex.Message}");
                throw;
            }
        }
    }
}
