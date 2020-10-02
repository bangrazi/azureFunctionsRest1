using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Linq;

namespace azureFunctionsRest1
{
    public class ValuesPutFunction
    {
        public ValuesPutFunction(IService service) {
            this.service = service;
        }

        private readonly IService service;

        [FunctionName("ValuesPutFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = "values/{id:int}")] HttpRequest request,
            ILogger log, int id)
        {
            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            Value valueIn = JsonSerializer.Deserialize<Value>(requestBody);

            if(valueIn.Id != id) {
                return new BadRequestObjectResult($"Object identifiers do not match, {id} != {valueIn.Id}");
            }

            Value value = service.Values.SingleOrDefault(v => v.Id == id);
            if(value == null) {
                return new NotFoundResult();
            }

            value.Name = valueIn.Name;

            return new AcceptedResult();
        }
    }
}
