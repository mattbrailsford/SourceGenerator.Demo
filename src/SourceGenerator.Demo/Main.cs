using System.Threading;
using System.Threading.Tasks;

namespace SourceGenerator.Demo
{
    public class Main
    {
        public async Task Test()
        {
            var ct = CancellationToken.None;

            // Sync API
            var store = new Store()
                .SetName("Test Name");

            // Async API
            var store2 = await new Store()
                .SetNameAsync("Test Name");

            // Fluent Sync API
            var order = new Order()
                .SetOrderNumber("CART-0001")
                .SetOrderNumber("ORDER-0001")
                .AddProduct("test")
                .AddProduct("test2", 2);

            // Fluent Async API
            var order2 = await new Order()
                .SetOrderNumberAsync("CART-0001", ct)
                .SetOrderNumberAsync("ORDER-0001", ct)
                .SetIsFinalizedAsync(false, ct)
                .AddProductAsync("test", ct)
                .AddProductAsync("test2", 2, ct);

            // Other examples
            var country = await new Country()
                .SetCodeAsync("GB")
                .SetNameAsync("United Kingdom");

            var currency = await new Currency()
                .SetCodeAsync("GB")
                .SetNameAsync("United Kingdom");
        }
    }
}
