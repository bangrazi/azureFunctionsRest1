using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace azureFunctionsRest1
{
    public class ValuesPostFunction
    {
        public ValuesPostFunction(IService service) {
            this.service = service;
        }

        private readonly IService service;

        [FunctionName("ValuesPostFunction")]
        public async Task<ActionResult<Value>> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "values")] HttpRequest request,
            ILogger log)
        {
            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();

            int max = service.Values.Max(v => v.Id);
            Value value = new Value() { Id = max + 1, Name = requestBody };
            service.Values.Add(value);

            return new CreatedResult($"/api/values/{value.Id}", value);
        }
    }
}
