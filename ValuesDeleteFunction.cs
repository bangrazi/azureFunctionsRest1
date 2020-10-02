using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace azureFunctionsRest1
{
    public class ValuesDeleteFunction
    {
        public ValuesDeleteFunction(IService service) {
            this.service = service;
        }

        private readonly IService service;

        [FunctionName("ValuesDeleteFunction")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "values/{id:int}")] HttpRequest req,
            ILogger log, int id)
        {
            Value value = service.Values.SingleOrDefault(v => v.Id == id);
            if(value == null) {
                return new NotFoundResult();
            }
            else {
                service.Values.Remove(value);
                return new NoContentResult();
            }
        }
    }
}
