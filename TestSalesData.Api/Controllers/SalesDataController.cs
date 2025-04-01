using Microsoft.AspNetCore.Mvc;
using TestSalesData.Service.DataService;

namespace TestSalesData.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesDataController(ISalesDataService salesDataService, ILogger<SalesDataController> logger) : ControllerBase
    {
      
        [HttpGet(Name = "GetAllSalesData")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var filePath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"CsvData\data.csv");
                logger.LogInformation($" in GetAllSalesData , filepath {filePath}");

                var data = await salesDataService.GetAllSalesDataFromCsvAsync(filePath).ConfigureAwait(false);

                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError($"Error in GetAllSalesData , {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
