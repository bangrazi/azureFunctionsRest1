using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace azureFunctionsRest1
{
    public class ValuesGetFunction
    {
        public ValuesGetFunction(IService service) {
            this.service = service;
        }

        private readonly IService service;

        [FunctionName("ValuesGetFunction")]
        public ActionResult<IEnumerable<Value>> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "values/{id?}")] HttpRequest request,
            ILogger log, int? id)
        {
            if(id.HasValue) {
                Value value = service.Values.FirstOrDefault(v => v.Id == id);
                if(value == null) {
                    return new NotFoundResult();
                }
                else {
                    return new OkObjectResult(value);
                }
            }
            else {
                return new OkObjectResult(service.Values);
            }
        }
    }
}
