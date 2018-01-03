using System.IO;
using Inators.Azure.WebJobs.Extensions.Inject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace Inators.FunctionsInjectSample
{
    public static class FunctionConcat
    {
        [FunctionName("FunctionConcat")]
        public static IActionResult Concat([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req,
            [Inject]IConcatService concat,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];
            string surname = req.Query["surname"];

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;
            surname = surname ?? data?.surname;

            return name != null && surname !=null
                ? (ActionResult)new OkObjectResult(concat.Concat(name, surname))
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
