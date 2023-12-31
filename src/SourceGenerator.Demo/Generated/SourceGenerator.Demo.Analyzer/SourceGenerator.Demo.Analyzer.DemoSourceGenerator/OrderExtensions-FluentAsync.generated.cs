﻿// <auto-generated />

namespace SourceGenerator.Demo
{
    public static partial class OrderExtensions
    {
        public static async global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Order> SetCartNumberAsync(this global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Order> task, string cartNumber, global::System.Threading.CancellationToken cancellationToken = default) 
            => await (await task).SetCartNumberAsync(cartNumber, cancellationToken);

        public static async global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Order> SetOrderNumberAsync(this global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Order> task, string orderNumber, global::System.Threading.CancellationToken cancellationToken = default) 
            => await (await task).SetOrderNumberAsync(orderNumber, cancellationToken);

        public static async global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Order> SetTestAsync(this global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Order> task, string orderNumber, int testInt = 2, double testDecimal = 2.2, string testString = "hello", string? testString2 = null, bool testBool = true, char testChar = 'b', global::System.Guid testGuid = default, global::SourceGenerator.Demo.TestEnum testEnum = global::SourceGenerator.Demo.TestEnum.Value2, global::System.Threading.CancellationToken cancellationToken = default) 
            => await (await task).SetTestAsync(orderNumber, testInt, testDecimal, testString, testString2, testBool, testChar, testGuid, testEnum, cancellationToken);

        public static async global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Order> SetTestGenericAsync<T,T2>(this global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Order> task, global::System.Threading.CancellationToken cancellationToken = default) 
            where T : global::SourceGenerator.Demo.Entity, global::SourceGenerator.Demo.IEntity, new()
            where T2 : class
            => await (await task).SetTestGenericAsync<T,T2>(cancellationToken);

        public static async global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Order> AddProductAsync(this global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Order> task, string productReference, int quantity, global::System.Threading.CancellationToken cancellationToken = default) 
            => await (await task).AddProductAsync(productReference, quantity, cancellationToken);

        public static async global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Order> AddProductAsync(this global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Order> task, string productReference, global::System.Threading.CancellationToken cancellationToken = default) 
            => await (await task).AddProductAsync(productReference, cancellationToken);

        public static async global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Order> SetIsFinalizedAsync(this global::System.Threading.Tasks.Task<global::SourceGenerator.Demo.Order> task, bool isFinalized, global::System.Threading.CancellationToken cancellationToken = default) 
            => await (await task).SetIsFinalizedAsync(isFinalized, cancellationToken);

    }
}
