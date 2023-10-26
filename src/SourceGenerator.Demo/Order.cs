using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SourceGenerator.Demo
{
    public partial class Order : Entity 
    {
        public string CartNumber { get; internal set; }
        public string OrderNumber { get; internal set; }
        public bool IsFinalized { get; internal set; }


        private List<OrderLine> _orderLines;
        public IReadOnlyList<OrderLine> OrderLines => _orderLines.AsReadOnly();

        public Order()
        {
            _orderLines = new List<OrderLine>();
        }



        [EditorBrowsable(EditorBrowsableState.Never)]
        protected async Task<Order> SetCartNumberCoreAsync(string cartNumber, CancellationToken cancellationToken = default, bool sync = false)
        {
            CartNumber = cartNumber;

            // Common logic...

            if (sync)
            {
                // EventBus.Publish(new NotificationEvent());
            }
            else
            {
                // await EventBus.PublishAsync(new NotificationEventAsync());
            }

            return this;
        }

        //public Order SetCartNumber(string cartNumber)
        //    => SetCartNumberCoreAsync(cartNumber, default, true).GetAwaiter().GetResult();
        //public Task<Order> SetCartNumberAsync(string cartNumber, CancellationToken cancellationToken = default)
        //    => SetCartNumberCoreAsync(cartNumber, cancellationToken, false);




        [EditorBrowsable(EditorBrowsableState.Never)]
        protected async Task<Order> SetOrderNumberCoreAsync(string orderNumber, CancellationToken cancellationToken = default, bool sync = false)
        {
            OrderNumber = orderNumber;

            // Common logic...

            if (sync)
            {
                // EventBus.Publish(new NotificationEvent());
            }
            else
            {
                // await EventBus.PublishAsync(new NotificationEventAsync());
            }

            return this;
        }

        // An example CoreAsync method that we would expect
        // the Code Generator to generate a AddProduct sync method
        // and a AddProductAsync async method, but this is also 
        // an example of how an extension method can link to a defined method
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal Task<Order> AddProductCoreAsync(string productReference, int quantity, CancellationToken cancellationToken = default, bool sync = false)
        {
            var foundOrderLine = _orderLines.FirstOrDefault(x => x.ProductReference == productReference);
            if (foundOrderLine != null)
            {
                foundOrderLine.Quantity += quantity;
            }
            else
            {
                _orderLines.Add(new OrderLine { ProductReference = productReference, Quantity = quantity });
            }
            return Task.FromResult(this);
        }

        // Optional parameter conversion test
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Task<Order> SetTestCoreAsync(string orderNumber, int testInt = 2, double testDecimal = 2.2,
            string testString = "hello", string? testString2 = null, bool testBool = true, char testChar = 'b',
            Guid testGuid = default, TestEnum testEnum = TestEnum.Value2,
            CancellationToken cancellationToken = default, bool sync = false)
        {
            return Task.FromResult(this);
        }

        // Generic arguments conversion test
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Task<Order> SetTestGenericCoreAsync<T, T2>(CancellationToken cancellationToken = default, bool sync = false)
            where T : Entity, IEntity, new()
            where T2 : class
        {
            return Task.FromResult(this);
        }
    }
}