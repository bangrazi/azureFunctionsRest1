using System.Collections.Generic;

namespace azureFunctionsRest1 {
    public interface IService {
        ICollection<Value> Values { get; }
    }

    public class Service : IService {
        public Service() {
        }

        private readonly ICollection<Value> values = new List<Value>() {
            new Value() { Id = 1, Name = "one" },
            new Value() { Id = 2, Name = "two" },
            new Value() { Id = 3, Name = "three" },
            new Value() { Id = 4, Name = "four" },
            new Value() { Id = 5, Name = "five" },
            new Value() { Id = 6, Name = "six" },
        };

        public ICollection<Value> Values => values;
    }
}