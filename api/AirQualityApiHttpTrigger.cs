using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.Storage;
using Microsoft.Azure.Cosmos.Table;

namespace AirQuality
{

    public class MeasurementEntity: TableEntity
    {
        public double PM25 { get; set; }
        public double PM10 { get; set; }
        public string Date { get; set; }
    }


    public static class AirQualityApiHttpTrigger
    {
        [FunctionName("AirQualityApiHttpTrigger")]
        [StorageAccount("StorageAccountConn")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [Table("Measurements")] CloudTable cloudTable,
            ILogger log)
        {
            log.LogInformation("Cloudtable exists : " + cloudTable.Exists());

            TableQuery<MeasurementEntity> rangeQuery = new TableQuery<MeasurementEntity>()
            .Where( 
                //TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "MiernikWiata")
                TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, 
                        "MiernikWiata"),
                    TableOperators.And,
                    TableQuery.GenerateFilterConditionForDate(
                        "Timestamp", 
                        QueryComparisons.GreaterThanOrEqual, 
                       DateTimeOffset.UtcNow.AddHours(-24))
                    )
                );
            rangeQuery.TakeCount = 144;

            var entites = cloudTable.ExecuteQuery(rangeQuery, null);
           // log.LogInformation("entties result : " + JsonConvert.SerializeObject(entites));

            return new OkObjectResult(entites);
        }
    }
}
