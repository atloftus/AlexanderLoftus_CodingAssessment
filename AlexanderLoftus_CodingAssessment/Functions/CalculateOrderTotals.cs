using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AlexanderLoftus_CodingAssessment.Function_Handlers;


namespace AlexanderLoftus_CodingAssessment.Functions
{
    public static class CalculateOrderTotals
    {
        #region MAIN RUN METHOD
        [FunctionName("CalculateOrderTotals")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "CalculateOrderTotals")] HttpRequest req, ILogger log, Microsoft.Azure.WebJobs.ExecutionContext context)
        {
            return new OkObjectResult(new CalculateOrderTotalsFunctionHandler(context).CalculateOrderTotals());
        }
        #endregion
    }
}