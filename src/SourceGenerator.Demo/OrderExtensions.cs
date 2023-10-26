using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace SourceGenerator.Demo
{
    public static partial class OrderExtensions
    {
        // Example CoreAsync extension method where we would expect
        // the Code Generator to generate a AddProduct sync method
        // and a AddProductAsync async method
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static Task<Order> AddProductCoreAsync(this Order order, string productReference, CancellationToken cancellationToken = default, bool sync = false)
            => order.AddProductCoreAsync(productReference, 1, cancellationToken, sync);

        // Example entity extension method that we would expect
        // the Code Generator to create a Task<Entiy> fluent alternative
        public static Task<Order> SetIsFinalizedAsync(this Order order, bool isFinalized, CancellationToken cancellationToken = default)
        {
            order.IsFinalized = isFinalized;
            return Task.FromResult(order);
        }
    }
}
